using System;

namespace Assets.Model.Data
{
    [Serializable]
    public class InventoryItemData
    {
        public string Id;
        public int Count;

        public InventoryItemData(string id)
        {
            Id = id;
        }
    }
}
