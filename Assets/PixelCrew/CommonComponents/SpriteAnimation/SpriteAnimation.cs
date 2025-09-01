using System.Linq;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.SpriteAnimation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField]
        private string _initialAnimation = "Idle";

        [SerializeField]
        private AnimationSequence[] _clips;

        private AnimationSequence _currentSequence;

        private SpriteRenderer _spriteRenderer;

        private float _secondsPerFrame;
        private int _currentSprite;
        private float _nextFrameTime;
        private bool _isPlaying = true;

        public void SetAnimation(string animationName)
        {
            _currentSequence = _clips
                .FirstOrDefault(x => x.Name == animationName);

            if (_currentSequence == null)
            {
                enabled = false;
                _isPlaying = false;
                return;
            }

            StartAnimation();
            _secondsPerFrame = 1f / _currentSequence.FrameRate;
        }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            SetAnimation(_initialAnimation);
        }

        private void Update()
        {
            if (_currentSequence is null)
            {
                return;
            }

            if (_nextFrameTime > Time.time)
            {
                return;
            }

            if (_currentSequence.Sprites.Length <= _currentSprite)
            {
                if (_currentSequence.Loop)
                {
                    _currentSprite = 0;
                }
                else
                {
                    _currentSequence.OnAnimationEnd?.Invoke();
                    enabled = false;
                    _isPlaying = false;
                    return;
                }
            }

            _spriteRenderer.sprite = _currentSequence.Sprites[_currentSprite];

            _nextFrameTime += _secondsPerFrame;
            _currentSprite++;
        }

        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            enabled = true;
            _isPlaying = true;
            _currentSprite = 0;
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
            _nextFrameTime = Time.time;
        }
    }
}