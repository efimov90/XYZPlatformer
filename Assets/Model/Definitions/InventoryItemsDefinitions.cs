using System.Linq;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/InventoryItems", fileName = "InventoryItems")]
    public class InventoryItemsDefinitions : ScriptableObject
    {
        [SerializeField]
        private ItemDefinition[] _items;

#if UNITY_EDITOR

        public ItemDefinition[] ItemsForEditor
            => _items;

#endif

        public ItemDefinition Get(string id)
            => _items.FirstOrDefault(item => item.Id == id);
    }
}