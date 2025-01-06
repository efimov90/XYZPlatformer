using UnityEngine;

namespace Assets.CommonComponents
{
    public class HealComponent : MonoBehaviour
    {
        [SerializeField] private int _healAmount;

        public void Modify(GameObject target)
        {
            if (target.GetComponent<HealthComponent>() is HealthComponent healthComponent)
            {
                healthComponent.Heal(_healAmount);
            }
        }
    }
}
