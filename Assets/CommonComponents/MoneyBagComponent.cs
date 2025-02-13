using System;
using UnityEngine;

namespace Assets.CommonComponents
{
    public class MoneyBagComponent : MonoBehaviour
    {
        public event EventHandler<MoneyWithdrawed> MoneyWithdrawed;

        [SerializeField] public int Money;

        public void Withdraw(int count)
        {
            var cointsToWithdraw = Math.Min(count, Money);
            Money -= cointsToWithdraw;
            MoneyWithdrawed.Invoke(this, new MoneyWithdrawed(cointsToWithdraw));

            Debug.Log($"Money withdrawed {cointsToWithdraw}, current money: {Money}");
        }

        public void Give(int count)
        {
            Money += count;
            Debug.Log($"Money gived {count}, current money: {Money}");
        }
    }
}
