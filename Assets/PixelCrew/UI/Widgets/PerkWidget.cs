using Assets.Model;
using Assets.Model.Definitions.Repositories;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Widgets
{
    public class PerkWidget : MonoBehaviour, IItemRenderer<PerkDefinition>
    {
        private GameSession _gameSession;
        private PerkDefinition _perkDefinition;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private GameObject _isLocked;

        [SerializeField]
        private GameObject _isUsed;

        [SerializeField]
        private GameObject _isSelected;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            UpdateView();
        }

        public void SetData(PerkDefinition data, int index)
        {
            _perkDefinition = data;

            if (_gameSession != null)
            {
                UpdateView();
            }
        }

        public void OnSelect()
        {
            _gameSession.PerksModel.InterfaceSelection.Value = _perkDefinition.Id;
        }

        private void UpdateView()
        {
            _icon.sprite = _perkDefinition.Icon;
            _isUsed.SetActive(_gameSession.PerksModel.IsUsed(_perkDefinition.Id));
            _isSelected.SetActive(_gameSession.PerksModel.InterfaceSelection.Value == _perkDefinition.Id);
            _isLocked.SetActive(!_gameSession.PerksModel.IsUnlocked(_perkDefinition.Id));
        }
    }
}
