using Assets.PixelCrew.UI.Widgets;
using Assets.Model;
using UnityEngine;
using Assets.Model.Definitions.Player;
using Assets.Utils.Disposables;

namespace Assets.PixelCrew.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField]
        private ProgressBarWidget _healthBar;

        private GameSession _session;

        private CompositeDisposable _trash = new CompositeDisposable();

        private void Start()
        {
            _session = GameObject.FindObjectOfType<GameSession>();
            _trash.Retain(_session.PlayerData.Health.Subscribe(OnHealthChanged));

            OnHealthChanged(_session.PlayerData.Health.Value, _session.PlayerData.Health.Value);
        }

        private void OnHealthChanged(int newValue, int oldValue)
        {
            var maxHealth = _session.StatsModel.GetCurrentValue(StatId.Health);

            var healthDefinition = (float)newValue / maxHealth;

            _healthBar.SetProgress(healthDefinition);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
