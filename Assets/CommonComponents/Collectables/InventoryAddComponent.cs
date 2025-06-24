using Assets.Model.Definitions;
using Assets.PixelCrew.Creatures.Hero;
using UnityEngine;

namespace Assets.CommonComponents.Collectables
{
    public class InventoryAddComponent : MonoBehaviour
    {
        [InventoryId]
        [SerializeField]
        private string _id;

        [SerializeField]
        private int _count;

        public void Add(GameObject gameObject)
        {
            var hero = gameObject.GetComponent<Hero>();

            if (hero == null)
            {
                Debug.LogError("Hero component not found on the GameObject.");
                return;
            }

            hero.AddInInventory(_id, _count);
        }
    }
}
