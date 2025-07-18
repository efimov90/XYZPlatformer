using Assets.Model;
using Assets.Model.Definitions;
using Assets.Model.Definitions.Player;
using Assets.PixelCrew.CommonComponents.Collectables;
using Assets.PixelCrew.CommonComponents.ColliderBased;
using Assets.PixelCrew.CommonComponents.Effects.CameraRelated;
using Assets.PixelCrew.CommonComponents.Spawners;
using Assets.Utils;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Hero
{
    public class Hero : Creature
    {
        private const string SwordId = "Sword";
        private const string HealthPotionId = "HealthPotion";
        private const int maxThrowableSpawn = 3;

        [SerializeField]
        private float _slamDownVelocity;

        [SerializeField]
        private ParticleSystem _particleSystem;

        [SerializeField]
        private Cooldown _throwCooldown;

        [SerializeField]
        private AnimatorController _armedController;

        [SerializeField]
        private AnimatorController _disarmedController;

        [SerializeField]
        private CheckCircleOverlap _interactionRange;

        [SerializeField]
        protected AdjustableSpawnComponent _throwSpawnComponent;

        [SerializeField]
        private GameObject _candle;

        private CameraShakeEffect _cameraShakeEffect;

        private BuffComponent _buffComponent;

        private bool _allowSecondJump;

        private GameSession _gameSession;

        private bool _isDashing;
        private float _dashDirection;

        public bool IsDoubleJumpAllowed => _allowSecondJump && _gameSession.PerksModel.IsDoubleJumpAllowed;

        public string QuickInventorySelectedId => _gameSession.QuickInventory.SelectedItem.Id;

        public bool CanThrow
        {
            get
            {
                var canThrow = DefinitionsFacade.Instance.InventoryItemDefinitions.Get(QuickInventorySelectedId).HasTag(ItemTag.Throwable);

                if (!canThrow)
                {
                    return false;
                }

                var throwableCount = _gameSession.PlayerData.Inventory.GetCountOf(QuickInventorySelectedId);

                if (QuickInventorySelectedId == SwordId)
                {
                    return throwableCount > 1;
                }

                return throwableCount > 0;
            }
        }

        public bool CanThrowMultiple
        {
            get
            {
                if (!_gameSession.PerksModel.IsSuperThrowAllowed)
                {
                    return false;
                }

                var canThrow = DefinitionsFacade.Instance.InventoryItemDefinitions.Get(QuickInventorySelectedId).HasTag(ItemTag.Throwable);

                if (!canThrow)
                {
                    return false;
                }

                var throwableCount = _gameSession.PlayerData.Inventory.GetCountOf(QuickInventorySelectedId);

                if (QuickInventorySelectedId == SwordId)
                {
                    return throwableCount >= maxThrowableSpawn + 1;
                }

                return throwableCount >= maxThrowableSpawn;
            }
        }

        private void Start()
        {
            _cameraShakeEffect = FindObjectOfType<CameraShakeEffect>();
            _gameSession = FindObjectOfType<GameSession>();
            _gameSession.PlayerData.Inventory.InventoryChanged += OnInventoryChaged;
            _gameSession.StatsModel.OnUpgraded += OnUpgradedStat;
            _healthComponent.SetHealthSilently(_gameSession.PlayerData.Health.Value);
            UpdateHeroWeapon();
        }

        protected override void FixedUpdate()
        {
            if (_isDashing)
            {
                var velocityX = _dashDirection * CalculateSpeed();
                var velocityY = CalculateVelocityY();

                _rigidbody2D.velocity = new Vector2(velocityX, velocityY);

                _animator.SetBool(_isOnFloorHashString, IsOnFloor);
                _animator.SetFloat(_verticalVelocityHashString, _rigidbody2D.velocity.y);
                _animator.SetBool(_isRunningHashString, Direction.x != 0);

                UpdateSpriteDirection(Direction);
            }
            else
            {
                base.FixedUpdate();
            }
        }

        private void OnUpgradedStat(StatId statId)
        {
            switch (statId)
            {
                case StatId.Health:
                    var oldLevel = _gameSession.StatsModel.GetCurrentLevel(statId) - 1;

                    if (oldLevel < 0 || oldLevel >= _gameSession.StatsModel.GetStatDefinition(statId).Levels.Length)
                    {
                        return;
                    }

                    var oldMaxHp = _gameSession.StatsModel.GetValue(statId, oldLevel);

                    var newMaxHp = _gameSession.StatsModel.GetCurrentValue(statId);

                    _gameSession.PlayerData.Health.Value = (int)(_gameSession.PlayerData.Health.Value / oldMaxHp * newMaxHp);
                    _healthComponent.SetHealth(_gameSession.PlayerData.Health.Value);
                    break;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _buffComponent = GetComponent<BuffComponent>();

            _animator.runtimeAnimatorController = _disarmedController;
        }

        public void OnHealthChanged(int currentHealth)
        {
            if(_gameSession.PlayerData.Health.Value > currentHealth)
            {
                _cameraShakeEffect.Shake();
            }

            _gameSession.PlayerData.Health.Value = currentHealth;
        }

        public void OpenInventory()
        {
            if (_gameSession.Inventory.IsOpened)
            {
                return;
            }

            _gameSession.Inventory.IsOpened = true;

            WindowUtils.CreateWindow("UI/InventoryWindow");
        }

        public void Dash()
        {
            if(_gameSession.PerksModel.Used != "Dash")
            {
                return;
            }

            StartCoroutine(DashCorutine());
        }

        private IEnumerator DashCorutine()
        {
            if (!_gameSession.PerksModel.IsCooldownActive && !_isDashing)
            {
                _isDashing = true;
                _dashDirection = Direction.x * 3;

                yield return new WaitForSeconds(0.2f);

                _dashDirection = 0;
                _isDashing = false;

                yield return _gameSession.PerksModel.StartCooldown();
            }
        }

        public void ToggleLight()
        {
            _candle.SetActive(!_candle.activeSelf);
        }

        public void AddInInventory(string id, int count)
        {
            _gameSession.PlayerData.Inventory.Add(id, count);
        }

        public void RemoveFromInventory(string id, int count)
        {
            _gameSession.PlayerData.Inventory.Remove(id, count);
        }

        private void OnInventoryChaged(string id, int delta, int count)
        {
            if (id == SwordId)
            {
                UpdateHeroWeapon();
            }

            if (id == "Coin" && delta < 0)
            {
                SpawnCoins(-delta);
            }
        }

        protected override float CalculateVelocityY()
        {
            var isJumping = Direction.y > 0;

            if (IsOnFloor)
            {
                _allowSecondJump = true;
            }

            return base.CalculateVelocityY();
        }

        protected override float CalculateSpeed()
            => _gameSession.StatsModel.GetCurrentValue(StatId.Speed);

        protected override float CalculateJumpVelocity(float velocityY)
        {
            if (IsOnFloor)
            {
                DoJumpEffects();
                velocityY += _jumpSpeed * _buffComponent.JumpBoostAmount;
            }
            else if (IsDoubleJumpAllowed)
            {
                DoJumpEffects();
                velocityY = _jumpSpeed * _buffComponent.JumpBoostAmount;
                _allowSecondJump = false;
                StartCoroutine(_gameSession.PerksModel.StartCooldown());
            }

            return velocityY;
        }

        public void Interact()
        {
            _interactionRange.Check();
        }

        public override void Attack()
        {
            if (_gameSession.PlayerData.Inventory.GetCountOf(SwordId) <= 0)
            {
                return;
            }

            base.Attack();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (IsOnFloor)
            {
                var contact = collision.contacts[0];
                if (contact.relativeVelocity.y >= _slamDownVelocity)
                {
                    SpawnSlamDust();
                }
            }
        }

        public void SpawnCoins(int count)
        {
            var burst = _particleSystem.emission.GetBurst(0);
            burst.count = count;
            _particleSystem.emission.SetBurst(0, burst);

            _particleSystem.gameObject.SetActive(true);
            _particleSystem?.Play();
        }

        public void UpdateHeroWeapon()
        {
            if (_gameSession.PlayerData.Inventory.GetCountOf(SwordId) > 0)
            {
                _animator.runtimeAnimatorController = _armedController;
            }
            else
            {
                _animator.runtimeAnimatorController = _disarmedController;
            }
        }

        public void Throw(bool multiple = false)
        {
            if (!CanThrow)
            {
                return;
            }

            if (!_throwCooldown.IsReady)
            {
                return;
            }

            if (multiple && CanThrowMultiple)
            {
                Debug.Log("Throw multiple");
                StartCoroutine(nameof(ThrowMultiple));
                StartCoroutine(_gameSession.PerksModel.StartCooldown());
            }
            else
            {
                Debug.Log("Throw single");
                ThrowAndRemoveFromInventory();
            }

            _throwCooldown.Reset();
        }

        private IEnumerator ThrowMultiple()
        {
            for (var i = 0; i < 3; i++)
            {
                ThrowAndRemoveFromInventory();
                yield return new WaitForSeconds(0.3f);
            }
        }

        private void ThrowAndRemoveFromInventory()
        {
            var isThrowable = DefinitionsFacade.Instance.InventoryItemDefinitions.Get(QuickInventorySelectedId).HasTag(ItemTag.Throwable);

            if (!isThrowable)
            {
                return;
            }

            _playSoundsComponent?.Play("Range");
            _animator.SetTrigger(_throwHashString);
        }

        public void OnThrowed()
        {
            var throwable = DefinitionsFacade.Instance.ThrowableItemsDefinition.Get(QuickInventorySelectedId);

            if (throwable.IsDefault)
            {
                return;
            }

            _throwSpawnComponent.SetPrefab(throwable.ProjectilePrefab);
            var projectile = _throwSpawnComponent.Spawn();
            var modifyHealthComponent = projectile.GetComponent<ModifyHealthComponent>();

            if (modifyHealthComponent != null)
            {
                modifyHealthComponent.HpDelta *= (int)_gameSession.StatsModel.GetCurrentValue(StatId.RangeDamage);
            }

            RemoveFromInventory(QuickInventorySelectedId, 1);
        }

        public void UseHealthPotion()
        {
            if (_gameSession.PlayerData.Inventory.GetCountOf(HealthPotionId) <= 0)
            {
                return;
            }

            _gameSession.PlayerData.Inventory.Remove(HealthPotionId, 1);
            _healthComponent.ModifyHealth(Random.Range(5, 25));
        }

        public void NextQuickItem()
        {
            _gameSession.QuickInventory.SetNextItem();
        }

        private void OnDestroy()
        {
            if (_gameSession != null)
            {
                _gameSession.PlayerData.Inventory.InventoryChanged -= OnInventoryChaged;
            }
        }
    }
}