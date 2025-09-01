using Assets.PixelCrew.CommonComponents.Health;
using Assets.Utils.Disposables;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Bosses
{
    public class HealthAnimationGlue : MonoBehaviour
    {
        private static readonly int Health = Animator.StringToHash("Health");

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private Animator _animator;

        private void Awake()
        {
            _trash.Retain(_healthComponent.OnHealthChanged.Subscribe(OnHealthChanged));

            OnHealthChanged(_healthComponent.Health);
        }

        private void OnHealthChanged(int newValue)
        {
            _animator.SetInteger(Health, newValue);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
