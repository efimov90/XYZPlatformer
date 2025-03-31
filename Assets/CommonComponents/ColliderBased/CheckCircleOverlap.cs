using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.CommonComponents.ColliderBased
{
    public class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField]
        private float _radius = 1f;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private string[] _tags;

        [SerializeField]
        private OnOverlapEvent _onOverlap;

        private readonly Collider2D[] _interationResult = new Collider2D[10];

        public void Check()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
               transform.position,
               _radius,
               _interationResult,
               _layerMask);

            for (var i = 0; i < size; i++)
            {
                var overlapResult = _interationResult[i];

                if (_tags.Any(overlapResult.CompareTag))
                {
                    _onOverlap?.Invoke(overlapResult.gameObject);
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = HandlesUtils.TransparentRed;

            Handles.DrawSolidDisc(transform.position, Vector2.zero, _radius);
        }
#endif
    }
}
