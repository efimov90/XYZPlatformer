using System;
using System.Collections;
using UnityEngine;

namespace Assets.Utils
{
    public static class LerpAnimatedUtils
    {
        public static Coroutine LerpAnimated(
            this MonoBehaviour monoBehaviour,
            float startValue,
            float endValue,
            float animationTime,
            Action<float> onFrame)
        {
            return monoBehaviour.StartCoroutine(Animate(startValue, endValue, animationTime, onFrame));
        }

        private static IEnumerator Animate(
            float startValue,
            float endValue,
            float animationTime,
            Action<float> onFrame)
        {
            var elapsedTime = 0f;
            onFrame?.Invoke(startValue);

            while (elapsedTime < animationTime)
            {
                elapsedTime += Time.deltaTime;
                var progress = elapsedTime / animationTime;
                var alpha = Mathf.Lerp(startValue, endValue, progress);
                onFrame?.Invoke(alpha);

                yield return null;
            }

            onFrame?.Invoke(endValue);
        }
    }
}
