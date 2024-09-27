using UnityEngine;

namespace Assets.CommonComponents
{
    public class DestroyGameObjectComponent : MonoBehaviour
    {
        [SerializeField]
        private GameObject _objectToDestroy;

        public void DestroyObject()
        {
            Destroy(_objectToDestroy);
        }
    }
}