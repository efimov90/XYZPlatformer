using Assets.CommonComponents;
using Assets.CommonComponents.Collectables;
using Assets.CommonComponents.ColliderBased;
using Assets.PixelCrew.Model;
using Assets.Utils;
using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.PixelCrew.Creatures
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

        private BuffComponent _buffComponent;
        private MoneyBagComponent _moneyBagComponent;
        private SwordBagComponent _swordBagComponent;

        private bool _allowSecondJump = true;

        private GameSession _gameSession;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            _moneyBagComponent.SetMoneySilently(_gameSession.PlayerData.Money);
            _healthComponent.SetHealthSilently(_gameSession.PlayerData.Health);
            UpdateHeroWeapon();
        }

        protected override void Awake()
        {
            base.Awake();
            _buffComponent = GetComponent<BuffComponent>();
            _moneyBagComponent = GetComponent<MoneyBagComponent>();

            _animator.runtimeAnimatorController = _disarmedController;

            _moneyBagComponent.MoneyWithdrawed += OnMoneyWithdrawed;
            _moneyBagComponent.MoneyChanged += OnMoneyChanged;

            _swordBagComponent = GetComponent<SwordBagComponent>();

            _swordBagComponent.SwordsCountChanged += OnSwordsCountChanged;
        }

        private void OnSwordsCountChanged(object sender, SwordCountChanged e)
        {
            if(e.SwordsCount == _swordBagComponent.MinSwordCount)
            {
                _gameSession.PlayerData.IsArmed = true;
                UpdateHeroWeapon();
            }
        }

        public void OnHealthChanged(int currentHealth)
        {
            _gameSession.PlayerData.Health = currentHealth;
        }

        private void OnMoneyChanged(object sender, MoneyChanged e)
        {
            _gameSession.PlayerData.Money = e.Money;
        }

        private void OnMoneyWithdrawed(object sender, MoneyWithdrawed e)
        {
            if (_moneyBagComponent.Money > 0)
            {
                SpawnCoins(e.Money);
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
                SpawnJumpDust();
                velocityY += _jumpSpeed * _buffComponent.JumpBoostAmount;
            }
            else if (_allowSecondJump)
            {
                SpawnJumpDust();
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
            if (!_gameSession.PlayerData.IsArmed)
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

        [Obsolete("Не используется, указан в устаревшем компоненте")]
        public void ArmHero()
        {
            _gameSession.PlayerData.IsArmed = true;
            UpdateHeroWeapon();
        }

        public void UpdateHeroWeapon()
        {
            if (_gameSession.PlayerData.IsArmed)
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

            if (_swordBagComponent.SwordCount <= _swordBagComponent.MinSwordCount)
            {
                return;
            }

            if (!_throwCooldown.IsReady)
            {
                return;
            }

            if(multiple
                && _swordBagComponent.SwordCount >= _swordBagComponent.MinSwordCount + maxSwordsSpawn)
            {
                Debug.Log("Throw multiple");
                StartCoroutine(nameof(ThrowMultiple));
            }
            else
            {
                Debug.Log("Throw single");
                _swordBagComponent.Withdraw(1);
                _animator.SetTrigger(_throwHashString);
            }

            _throwCooldown.Reset();
        }

        private IEnumerator ThrowMultiple()
        {
            for (var i = 0; i < 3; i++)
            {
                _animator.SetTrigger(_throwHashString);
                _swordBagComponent.Withdraw(1);
                yield return new WaitForSeconds(0.2f);
            }
        }

        public void OnThrowed()
        {
            _spawnComponent.Spawn("SwordProjectile");
            //_gameSession.PlayerData.IsArmed = false;
            //UpdateHeroWeapon();
        }
    }
}