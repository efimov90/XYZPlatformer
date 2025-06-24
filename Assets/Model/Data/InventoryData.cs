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

        public delegate void InventoryChangedEventHandler(string id, int delta, int count);

        public event InventoryChangedEventHandler InventoryChanged;

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

            InventoryChanged?.Invoke(id, count, GetCountOf(id));
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
                var delta = -item.Count;
                _inventoryItems.Remove(item);

                InventoryChanged?.Invoke(id, delta, GetCountOf(id));
                return;
            }

            item.Count -= count;

            InventoryChanged?.Invoke(id, -count, GetCountOf(id));
        }

        public void Remove(InventoryItemData[] required)
        {
            foreach (var item in required)
            {
                Remove(item.Id, item.Count);
            }
        }

        public int GetCountOf(string id)
        {
            var item = GetItem(id);
            return item?.Count ?? 0;
        }

        public bool Contains(InventoryItemData[] required)
            => required.All(ri => _inventoryItems.Any(ii => ii.Id == ri.Id && ii.Count >= ri.Count));

        public InventoryItemData GetItem(string id)
            => _inventoryItems.FirstOrDefault(i => i.Id == id);
    }
}
