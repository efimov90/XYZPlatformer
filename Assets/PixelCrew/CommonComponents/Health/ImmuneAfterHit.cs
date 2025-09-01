using Assets.Utils.Disposables;
using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Health
{
    [RequireComponent(typeof(HealthComponent))]
    public class ImmuneAfterHit : MonoBehaviour
    {
        private HealthComponent _healthComponent;
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        [SerializeField] private float _immuneTime;
        private Coroutine _corutine;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _trash.Retain(_healthComponent.OnDamage.Subscribe(OnDamage));
        }

        private void OnDamage()
        {
            TryStop();

            if (_immuneTime <= 0)
            {
                return;
            }

            _corutine = StartCoroutine(MakeImmune());
        }

        private void TryStop()
        {
            if (_corutine == null)
            {
                return;
            }

            StopCoroutine(_corutine);
            _corutine = null;
        }

        private IEnumerator MakeImmune()
        {
            _healthComponent.Lock.Retain(this);
            yield return new WaitForSeconds(_immuneTime);
            _healthComponent.Lock.Release(this);
        }

        private void OnDestroy()
        {
            TryStop();
            _trash.Dispose();
        }
    }
}
