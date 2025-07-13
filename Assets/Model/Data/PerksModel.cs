using Assets.Model.Data.Properties;
using Assets.Model.Definitions;
using Assets.Utils.Disposables;
using System;

namespace Assets.Model.Data
{
    public class PerksModel : IDisposable
    {
        private PlayerData _data;
        public readonly StringProperty InterfaceSelection = new StringProperty();

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        public event Action OnChanged;

        public PerksModel(PlayerData data)
        {
            _data = data;
            InterfaceSelection.Value = DefinitionsFacade.Instance.PerkRepository.All[0].Id;

            _trash.Retain(
                _data.Perks.Used.Subscribe((x, y) => OnChanged?.Invoke()));

            _trash.Retain(InterfaceSelection.Subscribe((x, y) => OnChanged?.Invoke()));
        }

        public string Used => _data.Perks.Used.Value;

        public IDisposable Subscribe(Action call)
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call);
        }

        public void Unlock(string perkId)
        {
            var perkDefinition = DefinitionsFacade.Instance.PerkRepository.Get(perkId);

            if(!_data.Inventory.HasResources(perkDefinition.Price))
            {
                return;
            }

            _data.Inventory.Remove(perkDefinition.Price);
            _data.Perks.AddPerk(perkId);

            OnChanged?.Invoke();
        }

        public void Use(string perkId)
        {
            if (!_data.Perks.IsUnlocked(perkId))
            {
                return;
            }

            _data.Perks.Used.Value = perkId;
        }

        public bool IsUsed(string perkId)
            => _data.Perks.Used.Value == perkId;

        public bool IsUnlocked(string perkId)
            => _data.Perks.IsUnlocked(perkId);

        public bool CanBuy(string perkId)
        {
            var definition = DefinitionsFacade.Instance.PerkRepository.Get(perkId);

            return _data.Inventory.HasResources(definition.Price);
        }

        public void Dispose()
        {
            _trash.Dispose();
        }
    }
}
