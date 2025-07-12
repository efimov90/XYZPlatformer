using System.Linq;
using UnityEngine;

namespace Assets.CommonComponents.SpriteAnimation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private string _initialAnimation = "Idle";
        [SerializeField] private AnimationSequence[] _clips;
        private AnimationSequence _currentSequence;

        private SpriteRenderer _spriteRenderer;

        private float _secondsPerFrame;
        private int _currentSprite;
        private float _nextFrameTime;
        private bool _isPlaying = true;

        public void SetAnimation(string animationName)
        {
            _currentSprite = 0;
            _currentSequence = _clips.FirstOrDefault(x => x.Name == animationName);

            if (_currentSequence == null)
            {
                return;
            }

            _secondsPerFrame = 1f / _currentSequence.FrameRate;
        }

        private void Start()
        {
            SetAnimation(_initialAnimation);

            _spriteRenderer = GetComponent<SpriteRenderer>();
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
                    _isPlaying = false;
                    return;
                }
            }

            _spriteRenderer.sprite = _currentSequence.Sprites[_currentSprite];
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
            _nextFrameTime = Time.time;
            _isPlaying = true;
            _currentSprite = 0;
        }
    }
}