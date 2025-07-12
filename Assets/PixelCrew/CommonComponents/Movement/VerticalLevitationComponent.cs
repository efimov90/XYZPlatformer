using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Movement
{
    public class VerticalLevitationComponent : MonoBehaviour
    {
        [SerializeField]
        private float _frequency = 1f;

        [SerializeField]
        private float _amplitude = 1f;

        [SerializeField]
        private bool _randomize = true;

        private Rigidbody2D _rigidbody;

        private float _originalY;
        private float _time;
        private float _seed = 0f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _originalY = _rigidbody.position.y;
            if (_randomize)
            {
                _seed = Random.value * Mathf.PI * 2;
            }
        }

        private void Update()
        {
            var position = _rigidbody.position;
            position.y = _originalY + (Mathf.Sin(_seed + (_time * _frequency)) * _amplitude);

            _rigidbody.MovePosition(position);

            _time += Time.fixedDeltaTime;
        }
    }
}
