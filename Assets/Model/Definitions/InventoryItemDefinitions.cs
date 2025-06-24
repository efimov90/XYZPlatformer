using System.Collections.Generic;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/InventoryItems", fileName = "InventoryItems")]
    public class InventoryItemDefinitions : ScriptableObject
    {
        [SerializeField]
        private ItemDefinition[] _items;
    }
}