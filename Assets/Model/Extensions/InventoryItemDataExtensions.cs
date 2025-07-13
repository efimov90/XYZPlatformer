using Assets.Model.Data;
using System.Collections.Generic;

namespace Assets.Model.Extensions
{
    public static class InventoryItemDataExtensions
    {
        public static IDictionary<string, int> ToDictionary(this IEnumerable<InventoryItemData> inventoryItemDatas)
        {
            var joined = new Dictionary<string, int>();

            foreach (var requiredItem in inventoryItemDatas)
            {
                if (joined.ContainsKey(requiredItem.Id))
                {
                    joined[requiredItem.Id] += requiredItem.Count;
                }
                else
                {
                    joined.Add(requiredItem.Id, requiredItem.Count);
                }
            }

            return joined;
        }
    }
}
