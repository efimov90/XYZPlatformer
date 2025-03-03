using Assets.CommonComponents;
using UnityEngine;

namespace Assets.PixelCrew.Creatures
{
    public class Creature : MonoBehaviour
    {
        #region Animation Keys
        private static readonly int _isOnFloorHashString =
            Animator.StringToHash("IsOnFloor");

        private static readonly int _verticalVelocityHashString =
            Animator.StringToHash("VerticalVelocity");

        private static readonly int _isRunningHashString =
            Animator.StringToHash("IsRunning");

        private static readonly int _hitHashString =
            Animator.StringToHash("Hit Trigger");

        private static readonly int _attackHashString =
            Animator.StringToHash("Attack Trigger");

        private static readonly int _isDeadHashString =
            Animator.StringToHash("IsDead");

        #endregion Animation Keys

        [Header("Parameters")]
        [SerializeField]
        protected bool _invertScale = false;

        [SerializeField]
        protected float _speed = 0f;

        [SerializeField]
        protected float _jumpSpeed;

        [SerializeField]
        protected float _damageJumpSpeed;

        [SerializeField]
        protected int _attackValue;

        [Header("Checkers")]
        [SerializeField]
        protected CheckCircleOverlap _attackRange;

        [SerializeField]
        protected LayerCollisionCheck _groundCollisionCheck;

        protected Vector2 _direction = Vector2.zero;
        protected Rigidbody2D _rigidbody2D;
        protected Animator _animator;
        protected HealthComponent _healthComponent;
        protected SpawnComponent _spawnComponent;

        public bool IsOnFloor { get; protected set; }

        public bool IsDead { get; protected set; } = false;

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public virtual void Attack()
        {
            _spawnComponent.Spawn("SwordParticle");

            _animator.SetTrigger(_attackHashString);
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(_hitHashString);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _damageJumpSpeed);
        }

        public void Die()
        {
            _animator.SetBool(_isDeadHashString, true);
            IsDead = true;
        }

        public void OnDied()
        {
            _animator.enabled = false;
        }

        protected virtual void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spawnComponent = GetComponent<SpawnComponent>();
            _healthComponent = GetComponent<HealthComponent>();
        }

        protected virtual void Update()
        {
            IsOnFloor = _groundCollisionCheck.IsTouchingLayer;
        }

        protected virtual float CalculateVelocityY()
        {
            var velocityY = _rigidbody2D.velocity.y;

            var isJumping = _direction.y > 0;

            if (isJumping)
            {
                var isFalling = _rigidbody2D.velocity.y <= 0;

                velocityY = isFalling
                    ? CalculateJumpVelocity(velocityY)
                    : velocityY;

            }
            else if (_rigidbody2D.velocity.y > 0)
            {
                velocityY *= 0.5f;
            }

            return velocityY;
        }

        protected virtual float CalculateJumpVelocity(float velocityY)
        {
            if (IsOnFloor)
            {
                velocityY += _jumpSpeed;
                SpawnJumpDust();
            }

            return velocityY;
        }

        protected void SpawnJumpDust() => _spawnComponent?.Spawn("JumpDust");

        protected void SpawnFootDust() => _spawnComponent?.Spawn("FootDust");

        protected void SpawnSlamDust() => _spawnComponent?.Spawn("SlamDust");

        private void FixedUpdate()
        {
            var velocityX = _direction.x * _speed;
            var velocityY = CalculateVelocityY();

            _rigidbody2D.velocity = new Vector2(velocityX, velocityY);

            _animator.SetBool(_isOnFloorHashString, IsOnFloor);
            _animator.SetFloat(_verticalVelocityHashString, _rigidbody2D.velocity.y);
            _animator.SetBool(_isRunningHashString, _direction.x != 0);

            UpdateSpriteDirection();
        }

        private void UpdateSpriteDirection()
        {
            var multiply = _invertScale ? -1 : 1;

            if (_direction.x > 0)
            {
                transform.localScale = new Vector3(multiply, 1, 1);
            }
            else if (_direction.x < 0)
            {
                transform.localScale = new Vector3(-multiply, 1, 1);
            }
        }

        public virtual void OnAttack()
        {
            _attackRange.Check();
        }
    }
}
