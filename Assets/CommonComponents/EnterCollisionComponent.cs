using UnityEngine;

namespace Assets.CommonComponents
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField]
        private string _tag;
        [SerializeField]
        private EnterEvent _action;

        private void OnCollisionEnter2D(Collision2D otherCollider)
        {
            Debug.Log("Collision with " + otherCollider.gameObject.name);

            if (otherCollider.collider.CompareTag(_tag))
            {
                Debug.Log("Collision with " + otherCollider.gameObject.name);
                _action?.Invoke(otherCollider.gameObject);
            }
        }
    }
}
