using UnityEngine;

namespace Assets.PixelCrew.Creatures.Weapons
{
    public class SinusoidalProjectile : BaseProjectile
    {
        [SerializeField]
        private float _frequency = 1f;

        [SerializeField]
        private float _amplitude = 1f;

        private float _originalY;
        private float _time;

        protected override void Start()
        {
            base.Start();
            _originalY = transform.position.y;
        }

        private void Update()
        {
            var position = _rigidbody.position;
            position.x += _direction * _speed;
            position.y = _originalY + (Mathf.Sin(_time * _frequency) * _amplitude);

            _rigidbody.MovePosition(position);

            _time += Time.fixedDeltaTime;
        }
    }
}
