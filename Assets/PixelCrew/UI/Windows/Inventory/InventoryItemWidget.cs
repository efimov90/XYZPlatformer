using Assets.Model;
using Assets.Model.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Windows.Inventory
{
    public class InventoryItemWidget : MonoBehaviour, IItemRenderer<ItemDefinition>
    {
        private GameSession _gameSession;
        private ItemDefinition _itemDefinition;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Text _count;

        [SerializeField]
        private GameObject _selection;

        public void SetData(ItemDefinition data, int index)
        {
            _itemDefinition = data;

            if (_gameSession != null)
            {
                UpdateView();
            }
        }

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            UpdateView();
        }

        public void OnSelect()
        {
            _gameSession.Inventory.InterfaceSelection.Value = _itemDefinition.Id;
        }

        private void UpdateView()
        {
            _icon.sprite = _itemDefinition.Icon;

            _count.text = $"{_gameSession.Inventory.GetCount(_itemDefinition.Id)}";

            _selection.SetActive(_gameSession.Inventory.InterfaceSelection.Value == _itemDefinition.Id);
        }
    }
}
