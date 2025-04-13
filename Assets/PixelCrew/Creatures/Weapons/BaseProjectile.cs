using UnityEngine;

namespace Assets.PixelCrew.Creatures.Weapons
{
    public class BaseProjectile : MonoBehaviour
    {
        [SerializeField]
        protected float _speed;

        [SerializeField]
        protected bool invertX = false;

        protected int _direction;
        protected Rigidbody2D _rigidbody;

        protected virtual void Start()
        {
            var modifier = invertX ? -1 : 1;
            _direction = modifier * transform.lossyScale.x > 0 ? 1 : -1;
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}
