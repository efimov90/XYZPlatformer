using Assets.CommonComponents.Collectables;
using Assets.CommonComponents.ColliderBased;
using Assets.CommonComponents.GameObjectBased;
using Assets.Model;
using Assets.Utils;
using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Hero
{
    public class Hero : Creature
    {
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
        protected SpawnComponent _throwSpawnComponent;

        private BuffComponent _buffComponent;

        private bool _allowSecondJump = true;

        private GameSession _gameSession;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            _gameSession.PlayerData.Inventory.InventoryChanged += OnInventoryChaged;
            _healthComponent.SetHealthSilently(_gameSession.PlayerData.Health.Value);
            UpdateHeroWeapon();
        }

        protected override void Awake()
        {
            base.Awake();
            _buffComponent = GetComponent<BuffComponent>();

            _animator.runtimeAnimatorController = _disarmedController;
        }

        public void OnHealthChanged(int currentHealth)
        {
            _gameSession.PlayerData.Health.Value = currentHealth;
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
            if (id == "Sword")
            {
                UpdateHeroWeapon();
            }

            if (id == "Coin" && delta < 0)
            {
                SpawnCoins(delta);
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

        protected override float CalculateJumpVelocity(float velocityY)
        {
            if (IsOnFloor)
            {
                DoJumpEffects();
                velocityY += _jumpSpeed * _buffComponent.JumpBoostAmount;
            }
            else if (_allowSecondJump)
            {
                DoJumpEffects();
                velocityY = _jumpSpeed * _buffComponent.JumpBoostAmount;
                _allowSecondJump = false;
            }

            return velocityY;
        }

        public void Interact()
        {
            _interactionRange.Check();
        }

        public override void Attack()
        {
            if (_gameSession.PlayerData.Inventory.GetCountOf("Sword") <= 0)
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
            if (_gameSession.PlayerData.Inventory.GetCountOf("Sword") > 0)
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
            const int maxSwordsSpawn = 3;

            var swordCount = _gameSession.PlayerData.Inventory.GetCountOf("Sword");

            if (swordCount <= 1)
            {
                return;
            }

            if (!_throwCooldown.IsReady)
            {
                return;
            }

            if (multiple && swordCount >= maxSwordsSpawn + 1)
            {
                Debug.Log("Throw multiple");
                StartCoroutine(nameof(ThrowMultiple));
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
                yield return new WaitForSeconds(0.2f);
            }
        }

        private void ThrowAndRemoveFromInventory()
        {
            _playSoundsComponent?.Play("Range");
            _animator.SetTrigger(_throwHashString);
            RemoveFromInventory("Sword", 1);
        }

        public void OnThrowed()
        {
            _throwSpawnComponent.Spawn("Sword");
        }

        public void UseHealthPotion()
        {
            if (_gameSession.PlayerData.Inventory.GetCountOf("HealthPotion") <= 0)
            {
                return;
            }

            _gameSession.PlayerData.Inventory.Remove("HealthPotion", 1);
            _healthComponent.ModifyHealth(10);
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