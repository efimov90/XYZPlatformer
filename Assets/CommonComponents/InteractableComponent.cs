using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents
{
    public class InteractableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        private void Interact()
        {
            _action?.Invoke();
        }
    }
}
