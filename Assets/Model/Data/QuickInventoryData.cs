using Assets.Model.Data.Properties;
using Assets.Model.Definitions;
using Assets.Utils.Disposables;
using System;
using UnityEngine;

namespace Assets.Model.Data
{
    public class QuickInventoryData : IDisposable
    {
        private readonly PlayerData _playerData;

        public InventoryItemData[] InventoryItems { get; private set; }

        public readonly IntProperty SelectedIndex = new IntProperty();

        public InventoryItemData SelectedItem => InventoryItems[SelectedIndex.Value];

        public event Action OnChanged;

        public QuickInventoryData(PlayerData playerData)
        {
            _playerData = playerData;

            RefreshItems();
            _playerData.Inventory.InventoryChanged += OnInventoryChanged;
        }

        public IDisposable Subscribe(Action subscribeHandler)
        {
            OnChanged += subscribeHandler;
            return new ActionDisposable(() => OnChanged -= subscribeHandler);
        }

        public void SetNextItem()
        {
            SelectedIndex.Value = (int) Mathf.Repeat(SelectedIndex.Value + 1, InventoryItems.Length);
        }

        private void OnInventoryChanged(string id, int delta, int count)
        {
            RefreshItems();
            SelectedIndex.Value = Mathf.Clamp(SelectedIndex.Value, 0, InventoryItems.Length - 1);
            OnChanged?.Invoke();
        }

        private void RefreshItems()
        {
            InventoryItems = _playerData.Inventory.GetAll(ItemTag.Usable);
        }

        public void Dispose()
        {
            _playerData.Inventory.InventoryChanged -= OnInventoryChanged;
        }
    }
}
