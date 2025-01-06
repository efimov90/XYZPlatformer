using UnityEngine;

namespace Assets.CommonComponents
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damage;

        public void Modify(GameObject target)
        {
            if (target.GetComponent<HealthComponent>() is HealthComponent healthComponent)
            {
                healthComponent.ApplyDamage(_damage);
            }
        }
    }
}
