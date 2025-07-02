using Assets.Model.Data.Properties;
using System;
using UnityEngine;

namespace Assets.Model.Data
{
    public class QuickInventoryData
    {
        private readonly PlayerData _playerData;

        public InventoryItemData[] InventoryItems { get; private set; }

        public readonly IntProperty SelectedIndex = new IntProperty();

        public QuickInventoryData(PlayerData playerData)
        {
            _playerData = playerData;

            InventoryItems = _playerData.Inventory.GetAll();
            _playerData.Inventory.InventoryChanged += OnInventoryChanged;
        }

        private void OnInventoryChanged(string id, int delta, int count)
        {
            InventoryItems = _playerData.Inventory.GetAll();
            SelectedIndex.Value = Mathf.Clamp(SelectedIndex.Value, 0, InventoryItems.Length - 1);
        }
    }
}
