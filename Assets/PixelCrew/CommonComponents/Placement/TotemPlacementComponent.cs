using Assets.PixelCrew.CommonComponents.Cooldowns;
using Assets.PixelCrew.Creatures.Mobs;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Placement
{
    [ExecuteInEditMode]
    public class TotemPlacementComponent : MonoBehaviour
    {
        [SerializeField]
        private CooldownComponent _rangeCooldownComponent;

        [SerializeField]
        private float placementDistance = 0.65f;
        private int lastChildCount = 0;

        static TotemPlacementComponent()
        {
        }

#if UNITY_EDITOR
        private void OnEnable()
        {
            EditorApplication.update += EditorUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= EditorUpdate;
        }
#endif

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
                    child.position = transform.position + (Vector3.up * placementDistance * i);
                    child.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = i;

                    if (child.GetChild(0).GetComponent<TotemHead>() is TotemHead totemHead
                        && totemHead._rangeCooldownComponent is null)
                    {
                        totemHead._rangeCooldownComponent = _rangeCooldownComponent;
                    }
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

            var positionUpper = transform.position + (Vector3.up * 3f);

            Gizmos.DrawLine(transform.position, positionUpper);
        }
    }
}
