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
    }
}
