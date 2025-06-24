using System;
using UnityEngine;

namespace Assets.CommonComponents.Sword
{
    public class SwordBagComponent : MonoBehaviour
    {
        public event EventHandler<SwordCountChanged> SwordsCountChanged;

        [SerializeField]
        public int SwordCount;

        [SerializeField]
        public int MinSwordCount;

        public void Withdraw(int count)
        {
            if(count > SwordCount + MinSwordCount)
            {
                Debug.LogError("Not enough swords");
                return;
            }

            var swordsToWithdraw = Math.Min(count, SwordCount);
            SwordCount -= swordsToWithdraw;
            Debug.Log($"Swords withdrawed {swordsToWithdraw}, current swords: {SwordCount}");

            SwordsCountChanged?.Invoke(this, new SwordCountChanged(SwordCount));
        }

        public void Give(int count)
        {
            SwordCount += count;
            Debug.Log($"Swords gived {count}, current swords: {SwordCount}");
            SwordsCountChanged?.Invoke(this, new SwordCountChanged(SwordCount));
        }

        public void SetSwordCountSilently(int count)
        {
            SwordCount = count;
        }
    }
}
