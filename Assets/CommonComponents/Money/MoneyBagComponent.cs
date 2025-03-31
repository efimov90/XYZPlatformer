using System;
using UnityEngine;

namespace Assets.CommonComponents.Money
{
    public class MoneyBagComponent : MonoBehaviour
    {
        public event EventHandler<MoneyChanged> MoneyChanged;
        public event EventHandler<MoneyWithdrawed> MoneyWithdrawed;

        [SerializeField]
        public int Money;

        public void Withdraw(int count)
        {
            var cointsToWithdraw = Math.Min(count, Money);
            Money -= cointsToWithdraw;
            MoneyWithdrawed.Invoke(this, new MoneyWithdrawed(cointsToWithdraw));

            Debug.Log($"Money withdrawed {cointsToWithdraw}, current money: {Money}");
            MoneyChanged?.Invoke(this, new MoneyChanged(Money));
        }

        public void Give(int count)
        {
            Money += count;
            Debug.Log($"Money gived {count}, current money: {Money}");
            MoneyChanged?.Invoke(this, new MoneyChanged(Money));
        }

        public void SetMoneySilently(int count)
        {
            Money = count;
        }
    }
}
