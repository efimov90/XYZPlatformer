using Assets.Model.Definitions;
using Assets.Model.Definitions.Repositories;
using Assets.Model.Extensions;
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
                Debug.LogWarning($"Attempted to remove an item with an invalid ID: {id}");
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

        public InventoryItemData[] GetAll(params ItemTag[] itemTags)
        {
            if (itemTags.Length < 1)
            {
                return _inventoryItems.ToArray();
            }

            var result = new List<InventoryItemData>();

            foreach (var inventoryItem in _inventoryItems)
            {
                var definition = DefinitionsFacade.Instance.Get(inventoryItem.Id);

                if (itemTags.Any(it => !definition.HasTag(it)))
                {
                    continue;
                }

                result.Add(inventoryItem);
            }

            return result.ToArray();
        }

        public void Remove(params InventoryItemData[] required) => Remove(required.ToDictionary());

        public void Remove(params ItemWithCount[] prices) => Remove(prices.ToDictionary());

        public void Remove(IDictionary<string, int> requiredItems)
        {
            foreach (var item in requiredItems)
            {
                Remove(item.Key, item.Value);
            }
        }

        public int GetCountOf(string id)
        {
            var item = GetItem(id);
            return item?.Count ?? 0;
        }

        public InventoryItemData GetItem(string id)
            => _inventoryItems.FirstOrDefault(i => i.Id == id);

        public bool HasResources(params InventoryItemData[] requiredtems) => HasResources(requiredtems.ToDictionary());

        public bool HasResources(params ItemWithCount[] requiredItems) => HasResources(requiredItems.ToDictionary());

        public bool HasResources(IDictionary<string, int> requiredItems)
        {
            var squashedInventory = _inventoryItems.ToDictionary();

            return requiredItems
                .All(ri => squashedInventory
                    .Any(sii => sii.Key == ri.Key && sii.Value >= ri.Value));
        }
    }
}
