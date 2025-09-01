using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.GameObjectBased
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