using System;

namespace Assets.CommonComponents.Money
{
    public class MoneyChanged : EventArgs
    {
        public MoneyChanged(int money)
        {
            Money = money;
        }

        public int Money { get; }
    }
}