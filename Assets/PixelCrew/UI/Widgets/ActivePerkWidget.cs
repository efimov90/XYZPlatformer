using Assets.Model;
using Assets.Model.Definitions;
using Assets.Model.Definitions.Repositories;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Widgets
{
    internal class ActivePerkWidget : MonoBehaviour
    {
        private PerkDefinition? _perkDefinition;
        private GameSession _gameSession;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private GameObject _isLocked;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();

            _gameSession.PerksModel.OnPerkUsed += OnPerkUsed;

            _gameSession.PerksModel.OnPerkCooldownStarted += OnPerkCooldownStarted;
            _gameSession.PerksModel.OnPerkCooldownEnded += OnPerkCooldownEnded;
            _isLocked.SetActive(false);
            UpdateView();
        }

        private void OnPerkCooldownEnded()
        {
            _isLocked.SetActive(false);
        }

        private void OnPerkCooldownStarted()
        {
            _isLocked.SetActive(true);
        }

        private void UpdateView()
        {
            _icon.gameObject.SetActive(_perkDefinition.HasValue);

            if (!_perkDefinition.HasValue)
            {
                return;
            }

            _icon.sprite = _perkDefinition.Value.Icon;
        }

        private void OnPerkUsed()
        {
            if(string.IsNullOrWhiteSpace(_gameSession.PerksModel.Used))
            {
                return;
            }

            _perkDefinition = DefinitionsFacade.Instance.PerkRepository.Get(_gameSession.PerksModel.Used);

            UpdateView();
        }

        private void OnDestroy()
        {
            _gameSession.PerksModel.OnPerkUsed -= OnPerkUsed;
            _gameSession.PerksModel.OnPerkCooldownStarted -= OnPerkCooldownStarted;
            _gameSession.PerksModel.OnPerkCooldownEnded -= OnPerkCooldownEnded;
        }
    }
}
