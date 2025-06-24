using Assets.Model.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Model.Data
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField]
        private List<InventoryItemData> _inventoryItems
            = new List<InventoryItemData>();

        public void Set(string id, int count)
        {
            if (count < 0)
            {
                return;
            }

            var itemDefinition = DefinitionsFacade.Instance.Get(id);

            if (itemDefinition.IsDefault)
            {
                Debug.LogWarning($"Attempted to set an item with an invalid ID: {id}");
                return;
            }

            var item = GetItem(id);

            if (item is null)
            {
                item = new InventoryItemData(id);
                _inventoryItems.Add(item);
            }

            item.Count = count;

            if (item.Count <= 0)
            {
                _inventoryItems.Remove(item);
            }
        }

        public void Add(string id, int count)
        {
            if (count <= 0)
            {
                return;
            }

            var itemDefinition = DefinitionsFacade.Instance.Get(id);

            if (itemDefinition.IsDefault)
            {
                Debug.LogWarning($"Attempted to add an item with an invalid ID: {id}");
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

        public void Remove(string id, int count)
        {
            if (count <= 0)
            {
                return;
            }

            var itemDefinition = DefinitionsFacade.Instance.Get(id);

            if (itemDefinition.IsDefault)
            {
                Debug.LogWarning($"Attempted to add an item with an invalid ID: {id}");
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

        public int GetCountOf(string id)
        {
            var item = GetItem(id);
            return item?.Count ?? 0;
        }

        public InventoryItemData GetItem(string id)
            => _inventoryItems.FirstOrDefault(i => i.Id == id);
    }
}
