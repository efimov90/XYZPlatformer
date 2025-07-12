using Assets.PixelCrew.UI.Widgets;
using Assets.Model;
using Assets.Model.Definitions;
using UnityEngine;

namespace Assets.PixelCrew.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField]
        private ProgressBarWidget _healthBar;

        private GameSession _session;

        private void Start()
        {
            _session = GameObject.FindObjectOfType<GameSession>();
            _session.PlayerData.Health.PropertyChanged += OnHealthChanged;

            OnHealthChanged(_session.PlayerData.Health.Value, _session.PlayerData.Health.Value);
        }

        private void OnHealthChanged(int newValue, int oldValue)
        {
            var maxHealth = DefinitionsFacade.Instance.PlayerDefinition.MaxHealth;

            var healthDefinition = (float)newValue / maxHealth;

            _healthBar.SetProgress(healthDefinition);
        }

        private void OnDestroy()
        {
            if (_session != null)
            {
                _session.PlayerData.Health.PropertyChanged -= OnHealthChanged;
            }
        }
    }
}
