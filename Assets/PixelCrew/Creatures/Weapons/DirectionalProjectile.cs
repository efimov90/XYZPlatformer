using UnityEngine;

namespace Assets.PixelCrew.Creatures.Weapons
{
    public class DirectionalProjectile : BaseProjectile
    {
        public void Launch(Vector2 direction)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(direction * _speed, ForceMode2D.Impulse);
        }
    }
}
