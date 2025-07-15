using Assets.PixelCrew.CommonComponents.Health;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Collectables
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _hpDelta;

        public int HpDelta
        {
            get => _hpDelta;
            set
            {
                if (_hpDelta == value)
                {
                    return;
                }

                _hpDelta = value;
            }
        }

        public void Modify(GameObject target)
        {
            if (target.GetComponent<HealthComponent>() is HealthComponent healthComponent)
            {
                healthComponent.ModifyHealth(_hpDelta);
            }
        }
    }
}
