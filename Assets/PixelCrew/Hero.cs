using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0f;

    [SerializeField]
    private float _jumpSpeed;

    [SerializeField]
    private LayerCollisionCheck _groundCollisionCheck;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.zero;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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

        _animator.SetBool("IsOnFloor", isOnFloor);
        _animator.SetFloat("VerticalVelocity", _rigidbody2D.velocity.y);
        _animator.SetBool("IsRunning", _direction.x != 0);
    }

    private bool IsOnFloor() => _groundCollisionCheck.IsTouchingLayer;
}
