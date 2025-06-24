using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/InventoryItems", fileName = "InventoryItems")]
    public class InventoryItemsDefinitions : ScriptableObject
    {
        [SerializeField]
        private ItemDefinition[] _items;
    }
}