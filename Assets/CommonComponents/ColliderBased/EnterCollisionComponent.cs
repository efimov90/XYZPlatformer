using UnityEngine;

namespace Assets.CommonComponents.ColliderBased
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField]
        private string _tag;
        [SerializeField]
        private EnterEvent _action;

        private void OnCollisionEnter2D(Collision2D otherCollider)
        {
            if (otherCollider.collider.CompareTag(_tag))
            {
                _action?.Invoke(otherCollider.gameObject);
            }
        }
    }
}
