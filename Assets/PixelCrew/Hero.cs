using UnityEngine;

public class Hero : MonoBehaviour
{
    private static readonly int _isOnFloorHashString = Animator.StringToHash("IsOnFloor");
    private static readonly int _verticalVelocityHashString = Animator.StringToHash("VerticalVelocity");
    private static readonly int _isRunningHashString = Animator.StringToHash("IsRunning");

    [SerializeField]
    private float _speed = 0f;

    [SerializeField]
    private float _jumpSpeed;

    [SerializeField]
    private LayerCollisionCheck _groundCollisionCheck;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.zero;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    internal void SaySomething()
    {
        Debug.Log("Something!");
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, _rigidbody2D.velocity.y);

        var isJumping = _direction.y > 0;

        var isOnFloor = IsOnFloor();

        if (isJumping)
        {
            if (isOnFloor && _rigidbody2D.velocity.y <= 0)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
        }
        else if (_rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
        }

        _animator.SetBool(_isOnFloorHashString, isOnFloor);
        _animator.SetFloat(_verticalVelocityHashString, _rigidbody2D.velocity.y);
        _animator.SetBool(_isRunningHashString, _direction.x != 0);

        UpdateSpriteDirection();
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private bool IsOnFloor() => _groundCollisionCheck.IsTouchingLayer;
}
