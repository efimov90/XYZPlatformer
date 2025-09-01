using Assets.Model.Data.Properties;
using Assets.Model.Definitions;
using Assets.Utils.Disposables;
using System;
using System.Linq;

namespace Assets.Model.Data
{
    public class InventoryModel : IDisposable
    {
        private PlayerData _data;
        private readonly CompositeDisposable _trash = new CompositeDisposable();
        public readonly StringProperty InterfaceSelection = new StringProperty();

        public bool IsOpened { get; set; }

        public InventoryModel(PlayerData data)
        {
            _data = data;
            InterfaceSelection.Value = DefinitionsFacade.Instance.InventoryItemDefinitions
                .GetAll()
                .FirstOrDefault().Id;

            _trash.Retain(InterfaceSelection.Subscribe((x, y) => OnChanged?.Invoke()));
        }

        public event Action OnChanged;

        public IDisposable Subscribe(Action call)
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call);
        }

        public void Dispose()
        {
            _trash.Dispose();
        }

        public int GetCount(string id) => _data.Inventory.GetCountOf(id);
    }
}
