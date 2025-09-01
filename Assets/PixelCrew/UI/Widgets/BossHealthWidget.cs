using Assets.PixelCrew.CommonComponents.Health;
using Assets.Utils;
using Assets.Utils.Disposables;
using System;
using UnityEngine;

namespace Assets.PixelCrew.UI.Widgets
{
    public class BossHealthWidget : MonoBehaviour
    {
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private ProgressBarWidget _healthBar;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        private int _maxHealth;

        private void Start()
        {
            _maxHealth = _healthComponent.Health;
            _trash.Retain(_healthComponent.OnHealthChanged.Subscribe(OnHealthChanged));
            _trash.Retain(_healthComponent.OnDie.Subscribe(HideUI));
        }

        [ContextMenu("Show UI")]
        public void ShowUI()
        {
            OnHealthChanged(_healthComponent.Health);
            this.LerpAnimated(0, 1, 1, SetAlpha);
        }

        [ContextMenu("Hide UI")]
        public void HideUI()
        {
            this.LerpAnimated(1, 0, 1, SetAlpha);
        }

        private void SetAlpha(float alpha)
        {
            _canvasGroup.alpha = alpha;
        }

        private void OnHealthChanged(int health)
        {
            _healthBar.SetProgress(health / (float)_maxHealth);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
