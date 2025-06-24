using Assets.Model.Definitions;
using System;

namespace Assets.Model.Data
{
    [Serializable]
    public class InventoryItemData
    {
        [InventoryId]
        public string Id;
        public int Count;

        public InventoryItemData(string id)
        {
            Id = id;
        }
    }
}
