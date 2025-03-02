using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents
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
    }
}