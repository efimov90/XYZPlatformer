using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.PixelCrew.CommonComponents
{
    public class TeleportComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        private float _alphaTime = 1f;

        [SerializeField]
        private float _moveTime = 1f;

        public void Teleport(GameObject gameObject)
        {
            Debug.Log("Teleporting " + gameObject.name + " to " + _target.position);
            gameObject.transform.position = _target.position;
        }

        private IEnumerator AnimateTeleport(GameObject target)
        {
            var sprite = target.GetComponent<SpriteRenderer>();

            var input = target.GetComponent<PlayerInput>();
            SetLockInput(input, true);

            yield return AlphaAnimation(sprite, 0f);
            target.SetActive(false);

            yield return MoveAnimation(target);
            target.SetActive(true);

            yield return AlphaAnimation(sprite, 1f);
            SetLockInput(input, false);
        }

        private void SetLockInput(PlayerInput input, bool isLocked)
        {
            if (input == null)
            {
                return;
            }

            input.enabled = !isLocked;
        }

        private IEnumerator MoveAnimation(GameObject target)
        {
            if (_target == null)
            {
                yield break;
            }

            var elapsedTime = 0f;
            var startPosition = target.transform.position;

            while (elapsedTime < _moveTime)
            {
                elapsedTime += Time.deltaTime;
                var progress = elapsedTime / _moveTime;
                target.transform.position = Vector3.Lerp(startPosition, _target.position, progress);
                yield return null;
            }

            target.transform.position = _target.position;
        }

        private IEnumerator AlphaAnimation(SpriteRenderer sprite, float targetAlpha)
        {
            if (sprite == null)
            {
                yield break;
            }

            var elapsedTime = 0f;
            var startAlpha = sprite.color.a;

            while (elapsedTime < _alphaTime)
            {
                elapsedTime += Time.deltaTime;
                var progress = elapsedTime / _alphaTime;
                var alpha = Mathf.Lerp(startAlpha, targetAlpha, progress);
                var color = sprite.color;
                color.a = alpha;
                sprite.color = color;

                yield return null;
            }

            var finalColor = sprite.color;
            finalColor.a = targetAlpha;
            sprite.color = finalColor;
        }
    }
}
