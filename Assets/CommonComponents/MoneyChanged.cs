using System;

namespace Assets.CommonComponents
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