using UnityEditor;
using UnityEngine;

namespace Assets.CommonComponents.Placement
{
    [ExecuteInEditMode]
    public class TotemPlacementComponent : MonoBehaviour
    {
        private float placementDistance = 0.7f;
        private int lastChildCount = 0;

        static TotemPlacementComponent()
        {
        }

        private void OnEnable()
        {
            EditorApplication.update += EditorUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= EditorUpdate;
        }

        private void EditorUpdate()
        {
            if (transform.childCount == lastChildCount)
            {
                // No change in child count
                return;
            }

            if (transform.childCount > lastChildCount)
            {
                // New child was added
                Transform newChild = transform.GetChild(transform.childCount - 1);
                OnChildAdded(newChild);
                lastChildCount = transform.childCount;
            }
            else if (transform.childCount < lastChildCount)
            {
                lastChildCount = transform.childCount;
            }

            for (int i = lastChildCount - 1; i >= 0; i--)
            {
                Transform child = transform.GetChild(i);
                if (child != null)
                {
                    child.position = transform.position + Vector3.up * placementDistance * i;
                    child.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = i;
                }
            }
        }

        private void OnChildAdded(Transform newChild)
        {
            newChild.gameObject.layer = gameObject.layer;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            var positionUpper = transform.position + Vector3.up * 3f;

            Gizmos.DrawLine(transform.position, positionUpper);
        }
    }
}
