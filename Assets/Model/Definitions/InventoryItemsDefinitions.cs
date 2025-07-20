using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/InventoryItems", fileName = "InventoryItems")]
    public class InventoryItemsDefinitions : ScriptableObject
    {
        [SerializeField]
        private ItemDefinition[] _items;

        public ItemDefinition Get(string id)
        {
            foreach (var item in _items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return default;
        }

        public IEnumerable<ItemDefinition> GetAll()
            => _items;
    }
}