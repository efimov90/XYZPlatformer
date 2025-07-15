using Assets.Model.Definitions;
using Assets.Model.Definitions.Player;
using Assets.Utils.Disposables;
using System;

namespace Assets.Model.Data
{
    public class StatsModel : IDisposable
    {
        private readonly PlayerData _playerData;

        public event Action OnChanged;

        public StatsModel(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public IDisposable Subscribe(Action call)
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call);
        }

        public void LevelUp(StatId statId)
        {
            var definition = GetStatDefinition(statId);
            var nextLevel = GetLevel(statId) + 1;

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
            _playerData.Levles.LevelUp(statId);

            OnChanged?.Invoke();
        }

        public float GetValue(StatId statId)
        {
            var definition = GetStatDefinition(statId);
            var level = definition.Levels[GetLevel(statId)];
            return level.Value;
        }

        public int GetLevel(StatId statId)
            => _playerData.Levles.GetLevel(statId);

        public void Dispose()
        {
        }

        private StatDefinition GetStatDefinition(StatId statId)
            => DefinitionsFacade.Instance.PlayerDefinition.GetStat(statId);
    }
}
