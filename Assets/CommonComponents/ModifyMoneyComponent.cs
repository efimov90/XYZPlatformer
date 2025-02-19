using UnityEngine;

namespace Assets.CommonComponents
{
    public class ModifyMoneyComponent : MonoBehaviour
    {
        [SerializeField] private int _moneyDelta;

        public void Modify(GameObject target)
        {
            if (target.GetComponent<MoneyBagComponent>() is MoneyBagComponent moneyBagComponent)
            {
                if (_moneyDelta > 0)
                {
                    moneyBagComponent.Give(_moneyDelta);
                }
                else
                {
                    moneyBagComponent.Withdraw(-_moneyDelta);
                }
            }
        }
    }
}
