using UnityEngine;

namespace Assets.CommonComponents.ColliderBased
{
    public class LayerCollisionCheck : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private bool _isTouchingLayer;

        private Collider2D _collider;

        public bool IsTouchingLayer => _isTouchingLayer;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            UpdateIsTouchingLayer();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            UpdateIsTouchingLayer();
        }

        private void UpdateIsTouchingLayer()
        {
            _isTouchingLayer = _collider.IsTouchingLayers(_layerMask);
        }
    }
}