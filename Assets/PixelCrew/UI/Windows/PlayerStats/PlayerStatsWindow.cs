using Assets.Model;
using Assets.Model.Definitions;
using Assets.Model.Definitions.Player;
using Assets.PixelCrew.UI.Widgets;
using Assets.Utils.Disposables;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Windows.PlayerStats
{
    public class PlayerStatsWindow : AnimatedWindow
    {
        [SerializeField]
        private Transform _statsContainer;

        [SerializeField]
        private StatWidget _prefab;

        [SerializeField]
        private Button _buyButton;

        [SerializeField]
        private ItemWidget _price;

        private DataGroup<StatDefinition, StatWidget> _statsGroup;

        private GameSession _gameSession;
        private CompositeDisposable _trash = new CompositeDisposable();

        protected override void Start()
        {
            base.Start();

            _statsGroup = new DataGroup<StatDefinition, StatWidget>(_prefab, _statsContainer);

            _gameSession = FindObjectOfType<GameSession>();

            _gameSession.StatsModel.InterfaceSelectedStat.Value = DefinitionsFacade.Instance.PlayerDefinition.Stats[0].Id;
            _trash.Retain(_gameSession.StatsModel.Subscribe(OnStatsChanged));
            _trash.Retain(_buyButton.onClick.Subscribe(OnUpgrade));

            OnStatsChanged();
        }

        private void OnUpgrade()
        {
            var selected = _gameSession.StatsModel.InterfaceSelectedStat.Value;
            _gameSession.StatsModel.LevelUp(selected);
        }

        private void OnStatsChanged()
        {
            var stats = DefinitionsFacade.Instance.PlayerDefinition.Stats;
            _statsGroup.SetData(stats);

            var selected = _gameSession.StatsModel.InterfaceSelectedStat.Value;
            var nextLevel = _gameSession.StatsModel.GetCurrentLevel(selected) + 1;

            var nextLevelDefinition = _gameSession.StatsModel.GetLevelDefinition(selected, nextLevel);
            _price.SetData(nextLevelDefinition.Price);

            _price.gameObject.SetActive(nextLevelDefinition.Price.Count != 0);
            _buyButton.gameObject.SetActive(nextLevelDefinition.Price.Count != 0);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
