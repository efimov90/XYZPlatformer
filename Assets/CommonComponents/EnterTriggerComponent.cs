using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField]
        private string _tag;

        [SerializeField]
        private UnityEvent _action;

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (otherCollider.CompareTag(_tag))
            {
                _action?.Invoke();
            }
        }
    }
}
