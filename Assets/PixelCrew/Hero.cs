using Assets.CommonComponents;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private static readonly int _isOnFloorHashString = Animator.StringToHash("IsOnFloor");
    private static readonly int _verticalVelocityHashString = Animator.StringToHash("VerticalVelocity");
    private static readonly int _isRunningHashString = Animator.StringToHash("IsRunning");
    private static readonly int _hitHashString = Animator.StringToHash("Hit Trigger");

    [SerializeField]
    private float _speed = 0f;

    [SerializeField]
    private float _jumpSpeed;

    [SerializeField]
    private float _damageJumpSpeed;

    [SerializeField]
    private LayerCollisionCheck _groundCollisionCheck;

    [SerializeField]
    private float _interactionRadius;

    [SerializeField]
    private LayerMask _interactionLayer;

    [SerializeField]
    private ParticleSystem _particleSystem;

    private Collider2D[] _interationResult = new Collider2D[1];

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.zero;
    private Animator _animator;
    private SpawnComponent _spawnComponent;
    private bool _allowSecondJump = true;

    public bool IsOnFloor { get; private set; }

    private void Update()
    {
        IsOnFloor = _groundCollisionCheck.IsTouchingLayer;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spawnComponent = GetComponent<SpawnComponent>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SaySomething()
    {
        Debug.Log("Something!");
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(_hitHashString);
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _damageJumpSpeed);
        SpawnCoins();
    }

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

    private float CalculateVelocityY()
    {
        var velocityY = _rigidbody2D.velocity.y;

        var isJumping = _direction.y > 0;

        if(IsOnFloor)
        {
            _allowSecondJump = true;
        }

        if (isJumping)
        {
            velocityY = CalculateJumpVelocity(velocityY);

        }
        else if (_rigidbody2D.velocity.y > 0)
        {
            velocityY *= 0.5f;
        }

        return velocityY;
    }

    private float CalculateJumpVelocity(float velocityY)
    {
        var isFalling = _rigidbody2D.velocity.y <= 0;

        if(!isFalling)
        {
            return velocityY;
        }

        if(IsOnFloor)
        {
            SpawnJumpDust();
            velocityY += _jumpSpeed;
        }
        else if (_allowSecondJump)
        {
            SpawnJumpDust();
            velocityY = _jumpSpeed;
            _allowSecondJump = false;
        }

        return velocityY;
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (_direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
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
            if(_interationResult[i].GetComponent<InteractableComponent>() is InteractableComponent interactableComponent)
            {
                interactableComponent.Interact();
                return;
            }
        }
    }

    public void SpawnFootDust()
    {
        _spawnComponent?.Spawn("FootDust");
    }

    public void SpawnJumpDust()
    {
        _spawnComponent?.Spawn("JumpDust");
    }

    public void SpawnCoins()
    {
        _particleSystem?.Play();
    }
}
