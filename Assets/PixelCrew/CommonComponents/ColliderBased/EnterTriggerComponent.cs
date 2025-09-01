using Assets.Utils;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.ColliderBased
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField]
        private string _tag;

        [SerializeField]
        private LayerMask _layerMask = ~0;

        [SerializeField]
        private EnterEvent _action;

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (!otherCollider.gameObject.IsInLayer(_layerMask))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(_tag) && !otherCollider.CompareTag(_tag))
            {
                return;
            }

            _action?.Invoke(otherCollider.gameObject);
        }
    }
}
