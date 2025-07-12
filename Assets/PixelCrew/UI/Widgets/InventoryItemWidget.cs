using Assets.Model;
using Assets.Model.Data;
using Assets.Model.Definitions;
using Assets.Utils.Disposables;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Widgets
{
    public class InventoryItemWidget : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private GameObject _selection;

        [SerializeField]
        private Text _value;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private int _index;

        public void SetData(InventoryItemData inventoryItemData, int index)
        {
            _index = index;

            var definition = DefinitionsFacade.Instance.Get(inventoryItemData.Id);

            _icon.sprite = definition.Icon;
            _value.text = definition.HasTag(ItemTag.Stackable)
                ? $"{inventoryItemData.Count}"
                : "";
        }

        private void Start()
        {
            var session = FindObjectOfType<GameSession>();

            _trash.Retain(
                session.QuickInventory.SelectedIndex.SubscribeAndInvoke(OnSelectedIndexChanged));
        }

        private void OnSelectedIndexChanged(int newValue, int _)
        {
            _selection.SetActive(newValue == _index);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
