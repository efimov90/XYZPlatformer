using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CommonComponents
{
    public class SwitchComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isOn;
        [SerializeField] private string _animationKey;

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
