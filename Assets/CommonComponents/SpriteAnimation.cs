using System.Collections;
using System.Collections.Generic;
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

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _secondsPerFrame = 1f / _frameRate;
            _nextFrameTime = Time.time + _secondsPerFrame;
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
                    Destroy(this);
                    return;
                }
            }

            _spriteRenderer.sprite = _sprites[_currentSprite];
            _nextFrameTime += _secondsPerFrame;
            _currentSprite++;
        }
    }
}