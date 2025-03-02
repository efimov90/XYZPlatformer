using Assets.CommonComponents;
using Assets.PixelCrew.Model;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.PixelCrew.Creatures
{
    public class Hero : Creature
    {
        [SerializeField]
        private float _slamDownVelocity;

        [SerializeField]
        private float _interactionRadius;

        [SerializeField]
        private LayerMask _interactionLayer;

        [SerializeField]
        private ParticleSystem _particleSystem;

        [SerializeField]
        private AnimatorController _armedController;

        [SerializeField]
        private AnimatorController _disarmedController;

        private Collider2D[] _interationResult = new Collider2D[1];

        private BuffComponent _buffComponent;
        private MoneyBagComponent _moneyBagComponent;
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
            var isJumping = _direction.y > 0;

            if (IsOnFloor)
            {
                _allowSecondJump = true;
            }

            //if (!isJumping)
            //{
            //    return 0f;
            //}

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
            var intersectionsCount = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _interactionRadius,
                _interationResult,
                _interactionLayer);

            Debug.Log(intersectionsCount);

            for (int i = 0; i < intersectionsCount; i++)
            {
                if (_interationResult[i].GetComponent<InteractableComponent>() is InteractableComponent interactableComponent)
                {
                    interactableComponent.Interact();
                    return;
                }
            }
        }

        public override void Attack()
        {
            if (!_gameSession.PlayerData.IsArmed)
            {
                return;
            }

            base.Attack();
        }

        public void OnAttack()
        {
            var attackedGameObjects = _attackRange.Check();

            Debug.Log($"{attackedGameObjects.Length}");

            for (int i = 0; i < attackedGameObjects.Length; i++)
            {
                if (attackedGameObjects[i].GetComponent<HealthComponent>() is HealthComponent healthComponent)
                {
                    Debug.Log($"Found attackable: {attackedGameObjects[i].name}");
                    healthComponent.ModifyHealth(-_attackValue);
                }
            }
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
    }
}