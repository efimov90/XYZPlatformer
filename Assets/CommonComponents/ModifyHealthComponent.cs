using UnityEngine;

namespace Assets.CommonComponents
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _hpDelta;

        public void Modify(GameObject target)
        {
            if (target.GetComponent<HealthComponent>() is HealthComponent healthComponent)
            {
                healthComponent.ModifyHealth(_hpDelta);
            }
        }
    }
}
