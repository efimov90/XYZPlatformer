using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private bool invertX = false;

        private int _direction;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            var modifier = invertX ? -1 : 1;
            _direction = modifier * transform.lossyScale.x > 0 ? 1 : -1;
            _rigidbody = GetComponent<Rigidbody2D>();
            var force = new Vector2(_direction * _speed, 0);
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
