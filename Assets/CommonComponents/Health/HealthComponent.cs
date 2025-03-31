using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HealthChanged _onHealthChanged;

        public void ModifyHealth(int hpDelta)
        {
            if(hpDelta <= 0 && _health <= 0)
            {
                return;
            }

            _health += hpDelta;

            if (hpDelta < 0)
            {
                _onDamage?.Invoke();
            }
            else if (hpDelta > 0)
            {
                _onHeal?.Invoke();
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }

            _onHealthChanged?.Invoke(_health);
        }

#if UNITY_EDITOR
        [ContextMenu("NotifyHealthChanged")]
        private void NotifyHealthChanged()
        {
            _onHealthChanged?.Invoke(_health);
        }
#endif

        public void SetHealthSilently(int health)
        {
            _health = health;
        }
    }
}