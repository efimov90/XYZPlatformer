using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onAnimationEnd;

        private SpriteRenderer _spriteRenderer;

        private float _secondsPerFrame;
        private int _currentSprite;
        private float _nextFrameTime;
        private bool _isPlaying = true;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _secondsPerFrame = 1f / _frameRate;
        }

        private void Update()
        {
            if(_nextFrameTime > Time.time)
            {
                return;
            }

            if(_sprites.Length <= _currentSprite)
            {
                if (_loop)
                {
                    _currentSprite = 0;
                }
                else
                {
                    _onAnimationEnd?.Invoke();
                    _isPlaying = false;
                    return;
                }
            }

            _spriteRenderer.sprite = _sprites[_currentSprite];
            _nextFrameTime += _secondsPerFrame;
            _currentSprite++;
        }

        private void OnBecameInvisible()
        {
            enabled = false;
        }

        private void OnBecameVisible()
        {
            enabled = _isPlaying;
        }

        private void OnEnable()
        {
            _nextFrameTime = Time.time + _secondsPerFrame;
            _isPlaying = true;
            _currentSprite = 0;
        }
    }
}