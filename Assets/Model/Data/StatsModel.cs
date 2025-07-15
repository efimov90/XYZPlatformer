using Assets.Model.Data.Properties;
using Assets.Model.Definitions;
using Assets.Model.Definitions.Player;
using Assets.Utils.Disposables;
using System;

namespace Assets.Model.Data
{
    public class StatsModel : IDisposable
    {
        private readonly PlayerData _playerData;
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        public event Action OnChanged;

        public ObservableProperty<StatId> InterfaceSelectedStat = new ObservableProperty<StatId>();

        public StatsModel(PlayerData playerData)
        {
            _playerData = playerData;
            _trash.Retain(InterfaceSelectedStat.Subscribe((x, y) => OnChanged?.Invoke()));
        }

        public IDisposable Subscribe(Action call)
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call);
        }

        public void LevelUp(StatId statId)
        {
            var definition = GetStatDefinition(statId);
            var nextLevel = GetCurrentLevel(statId) + 1;

            if (definition.Levels.Length >= nextLevel)
            {
                return;
            }

            var price = definition.Levels[nextLevel].Price;

            if (!_playerData.Inventory.HasResources(price))
            {
                return;
            }

            _playerData.Inventory.Remove(price);
            _playerData.Levels.LevelUp(statId);

            OnChanged?.Invoke();
        }

        public float GetCurrentValue(StatId statId)
            => GetCurrentLevelDefinition(statId).Value;

        public float GetValue(StatId statId, int level)
            => GetLevelDefinition(statId, level).Value;

        public StatLevelDefinition GetCurrentLevelDefinition(StatId statId)
            => GetLevelDefinition(statId, GetCurrentLevel(statId));

        public StatLevelDefinition GetLevelDefinition(StatId statId, int level)
            => GetStatDefinition(statId).Levels[level];

        public int GetCurrentLevel(StatId statId)
            => _playerData.Levels.GetLevel(statId);

        public void Dispose()
        {
            _trash.Dispose();
        }

        private StatDefinition GetStatDefinition(StatId statId)
            => DefinitionsFacade.Instance.PlayerDefinition.GetStat(statId);
    }
}
