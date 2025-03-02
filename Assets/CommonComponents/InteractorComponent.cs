using UnityEngine;

namespace Assets.CommonComponents
{
    public class InteractorComponent : MonoBehaviour
    {
        public void DoInteraction(GameObject gameObject)
        {
            gameObject.GetComponent<InteractableComponent>()?.Interact();
        }
    }
}
