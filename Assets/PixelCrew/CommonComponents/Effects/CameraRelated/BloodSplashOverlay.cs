using Assets.Model;
using Assets.Model.Definitions.Player;
using Assets.Utils.Disposables;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Effects.CameraRelated
{
    [RequireComponent(typeof(Animator))]
    public class BloodSplashOverlay : MonoBehaviour
    {
        private static readonly int Health = Animator.StringToHash("Health");
        private readonly CompositeDisposable _trash = new CompositeDisposable();
        private GameSession _gameSession;
        private Animator _animator;
        private Vector3 _overScale;

        [SerializeField]
        private Transform _overlay;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _overScale = _overlay.localScale - Vector3.one;

            _gameSession = FindObjectOfType<GameSession>();
            _trash.Retain(_gameSession.PlayerData.Health.SubscribeAndInvoke(OnHealthChanged));
        }

        private void OnHealthChanged(int newValue, int _)
        {
            var maxHealth = _gameSession.StatsModel.GetCurrentValue(StatId.Health);
            var healthNormalized = newValue / maxHealth;
            _animator.SetFloat(Health, healthNormalized);

            var overlayModifier = Mathf.Max(healthNormalized - 0.3f, 0f);
            _overlay.localScale = Vector3.one + _overScale * overlayModifier;
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
