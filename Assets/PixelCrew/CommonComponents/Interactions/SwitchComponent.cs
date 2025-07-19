using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Interactions
{
    public class SwitchComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isOn;
        [SerializeField] private string _animationKey;

        private void Start()
        {
            _animator?.SetBool(_animationKey, _isOn);
        }

        public void Switch()
        {
            _isOn = !_isOn;
            _animator.SetBool(_animationKey, _isOn);
        }

        [ContextMenu("Switch")]
        public void SwitchContextMenu()
        {
            Switch();
        }
    }
}
