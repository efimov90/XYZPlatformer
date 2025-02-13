using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.CommonComponents
{
    public class CheckCircleOverlap: MonoBehaviour
    {
        [SerializeField]
        private float _radius = 1f;

        [SerializeField]
        private string _tag;

        /// <summary>
        /// Небезопасная штука в плане конкурентности
        /// </summary>
        private Collider2D[] _interationResult = new Collider2D[5];

        public GameObject[] Check()
        {
            var intersectionsCount = Physics2D.OverlapCircleNonAlloc(
               transform.position,
               _radius,
               _interationResult);

            // Код из видео

            //var overlaps = new List<GameObject>();

            //for (int i = 0; i < intersectionsCount; i++)
            //{
            //    overlaps.Add(_interationResult[i].gameObject);
            //}

            //return overlaps.ToArray();

            return _interationResult
                .Select(x => x?.gameObject)
                .Where(x => x != null && x.tag == _tag)
                .ToArray();
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
