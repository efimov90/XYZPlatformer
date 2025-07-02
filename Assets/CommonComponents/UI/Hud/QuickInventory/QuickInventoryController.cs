using Assets.CommonComponents.UI.Widgets;
using Assets.Model;
using Assets.Model.Data;
using Assets.Utils.Disposables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CommonComponents.UI.Hud.QuickInventory
{
    public class QuickInventoryController : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private InventoryItemWidget _prefab;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private GameSession _session;
        private InventoryItemData[] _inventoryItems;
        private List<InventoryItemWidget> _createdItems = new List<InventoryItemWidget>();

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();

            Rebuild();
        }

        private void Rebuild()
        {
            _inventoryItems = _session.PlayerData.Inventory.GetAll();

            // Create required items

            for (var i = _createdItems.Count; i < _inventoryItems.Length; i++)
            {
                var itemWidget = Instantiate(_prefab, _container);
                _createdItems.Add(itemWidget);
            }

            // Update existing items

            for (var i = 0; i < _inventoryItems.Length; i++)
            {
                _createdItems[i].SetData(_inventoryItems[i], i);
                _createdItems[i].gameObject.SetActive(true);
            }

            // Hide unused items

            for (var i = _inventoryItems.Length; i < _createdItems.Count; i++)
            {
                _createdItems[i].gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            // TODO: unsubscribe model
        }
    }
}
