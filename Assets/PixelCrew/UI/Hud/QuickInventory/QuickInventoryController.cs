using Assets.PixelCrew.UI.Widgets;
using Assets.Model;
using Assets.Utils.Disposables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.PixelCrew.UI.Hud.QuickInventory
{
    public class QuickInventoryController : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private InventoryItemWidget _prefab;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private GameSession _session;
        private List<InventoryItemWidget> _createdItems = new List<InventoryItemWidget>();

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _trash.Retain(_session.QuickInventory.Subscribe(Rebuild));
            Rebuild();
        }

        private void Rebuild()
        {
            var inventoryItems = _session.QuickInventory.InventoryItems;

            // Create required items

            for (var i = _createdItems.Count; i < inventoryItems.Length; i++)
            {
                var itemWidget = Instantiate(_prefab, _container);
                _createdItems.Add(itemWidget);
            }

            // Update existing items

            for (var i = 0; i < inventoryItems.Length; i++)
            {
                _createdItems[i].SetData(inventoryItems[i], i);
                _createdItems[i].gameObject.SetActive(true);
            }

            // Hide unused items

            for (var i = inventoryItems.Length; i < _createdItems.Count; i++)
            {
                _createdItems[i].gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
