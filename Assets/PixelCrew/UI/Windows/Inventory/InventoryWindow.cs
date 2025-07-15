using Assets.Model;
using Assets.Model.Definitions;
using Assets.PixelCrew.UI.Widgets;
using Assets.Utils.Disposables;
using System.Linq;
using UnityEngine;

namespace Assets.PixelCrew.UI.Windows.Inventory
{
    public class InventoryWindow : AnimatedWindow
    {
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private PredefinedDataGroup<ItemDefinition, InventoryItemWidget> _inventoryItems;
        private GameSession _gameSession;

        [SerializeField]
        private Transform _itemsContainer;

        protected override void Start()
        {
            base.Start();

            _inventoryItems = new PredefinedDataGroup<ItemDefinition, InventoryItemWidget>(_itemsContainer);

            _gameSession = FindObjectOfType<GameSession>();

            _trash.Retain(_gameSession.Inventory.Subscribe(OnItemsChanged));

            _gameSession.Inventory.IsOpened = true;

            OnItemsChanged();
        }

        private void OnItemsChanged()
        {
            _inventoryItems.SetData(DefinitionsFacade.Instance.InventoryItemDefinitions
                .GetAll()
                .Where(x => _gameSession.Inventory.GetCount(x.Id) > 0)
                .ToList());
        }

        private void OnDestroy()
        {
            _gameSession.Inventory.IsOpened = false;

            _trash.Dispose();
        }
    }
}
