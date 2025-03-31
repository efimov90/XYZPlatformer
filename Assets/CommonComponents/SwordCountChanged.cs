using System;

namespace Assets.CommonComponents
{
    public class SwordCountChanged : EventArgs
    {
        public SwordCountChanged(int swordsCount)
        {
            SwordsCount = swordsCount;
        }

        public int SwordsCount { get; }
    }
}
