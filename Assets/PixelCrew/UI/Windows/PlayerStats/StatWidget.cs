using Assets.Model;
using Assets.Model.Definitions;
using Assets.Model.Definitions.Localization;
using Assets.Model.Definitions.Player;
using Assets.PixelCrew.UI.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Windows.PlayerStats
{
    public class StatWidget : MonoBehaviour, IItemRenderer<StatDefinition>
    {
        private GameSession _gameSession;
        private StatDefinition _statDefinition;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Text _name;

        [SerializeField]
        private Text _currentValue;

        [SerializeField]
        private Text _increaseValue;

        [SerializeField]
        private ProgressBarWidget _progress;

        [SerializeField]
        private GameObject _selector;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            UpdateView();
        }

        public void SetData(StatDefinition data, int index)
        {
            _statDefinition = data;

            if (_gameSession == null)
            {
                return;
            }

            UpdateView();
        }

        private void UpdateView()
        {
            var statsModel = _gameSession.StatsModel;

            _icon.sprite = _statDefinition.Icon;
            _name.text = LocalizationManager.Instance.Localize(_statDefinition.Name);

            var currentValue = statsModel.GetCurrentValue(_statDefinition.Id);
            var currentLevel = statsModel.GetCurrentLevel(_statDefinition.Id);
            var nextLevel = currentLevel + 1;
            var increaseValue = statsModel.GetValue(_statDefinition.Id, nextLevel);

            _currentValue.text = $"{currentValue}";
            _increaseValue.text = $"+{increaseValue - currentValue}";
            _increaseValue.gameObject.SetActive(increaseValue > 0);

            var maxLevel = DefinitionsFacade.Instance.PlayerDefinition.GetStat(_statDefinition.Id).Levels.Length - 1;

            _progress.SetProgress(currentLevel / (float)maxLevel);

            _selector.SetActive(statsModel.InterfaceSelectedStat.Value == _statDefinition.Id);
        }

        public void OnSelect()
        {
            _gameSession.StatsModel.InterfaceSelectedStat.Value = _statDefinition.Id;
        }
    }
}
