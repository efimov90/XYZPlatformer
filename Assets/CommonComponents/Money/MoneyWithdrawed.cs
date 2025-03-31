using System;

namespace Assets.CommonComponents.Money
{
    public class MoneyWithdrawed : EventArgs
    {
        public MoneyWithdrawed(int money)
        {
            Money = money;
        }

        public int Money { get; }
    }
}
