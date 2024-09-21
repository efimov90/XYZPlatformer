using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0f;

    private Vector2 _direction = Vector2.zero;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    internal void SaySomething()
    {
        Debug.Log("Something!");
    }

    private void Update()
    {
        if(_direction != Vector2.zero)
        {
            var delta = _direction * _speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + delta.x, transform.position.y + delta.y, transform.position.z);
        }
    }
}
