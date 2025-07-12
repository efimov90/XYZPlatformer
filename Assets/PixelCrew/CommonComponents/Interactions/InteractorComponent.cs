using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Interactions
{
    public class InteractorComponent : MonoBehaviour
    {
        public void DoInteraction(GameObject gameObject)
        {
            gameObject.GetComponent<InteractableComponent>()?.Interact();
        }
    }
}
