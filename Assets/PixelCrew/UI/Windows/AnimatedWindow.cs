using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.PixelCrew.UI.Windows
{
    public class AnimatedWindow : MonoBehaviour
    {
        private static readonly int _showTriggerHash = Animator.StringToHash("Show");
        private static readonly int _hideTriggerHash = Animator.StringToHash("Hide");

        private Animator _animator;

        protected virtual void Start()
        {
            AnalyticsEvent.ScreenVisit(gameObject.name);
            _animator = GetComponent<Animator>();

            if (_animator == null)
            {
                Debug.LogError("Animator component is missing on the AnimatedWindow.");
            }

            _animator.SetTrigger(_showTriggerHash);
        }

        public void Close()
        {
            _animator.SetTrigger(_hideTriggerHash);
        }

        public virtual void OnCloseAnimationComplete()
        {
            Destroy(gameObject);
        }
    }
}
