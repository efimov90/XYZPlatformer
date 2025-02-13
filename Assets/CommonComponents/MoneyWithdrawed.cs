using System;

namespace Assets.CommonComponents
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
