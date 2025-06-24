using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Model.Data
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField]
        private List<InventoryItemData> _inventoryItems
            = new List<InventoryItemData>();

        public void AddItem(string id, int count)
        {
            if (count <= 0)
            {
                return;
            }

            var item = GetItem(id);

            if (item is null)
            {
                item = new InventoryItemData(id);
                _inventoryItems.Add(item);
            }

            item.Count += count;
        }

        public void RemoveItem(string id, int count)
        {
            if (count <= 0)
            {
                return;
            }

            var item = GetItem(id);

            if (item is null)
            {
                return;
            }

            if (item.Count <= count)
            {
                _inventoryItems.Remove(item);
                return;
            }

            item.Count -= count;
        }

        public InventoryItemData GetItem(string id)
            => _inventoryItems.FirstOrDefault(i => i.Id == id);
    }
}
