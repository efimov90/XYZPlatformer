using UnityEngine;

namespace Assets.PixelCrew.CommonComponents
{
    public class TeleportComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        public void Teleport(GameObject gameObject)
        {
            Debug.Log("Teleporting " + gameObject.name + " to " + _target.position);
            gameObject.transform.position = _target.position;
        }
    }
}
