using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Collectables
{
    public class BuffComponent : MonoBehaviour
    {
        public float JumpBoostAmount { get; set; } = 1.0f;

        public void JumpBoost(float jumpBoostAmount)
        {
            JumpBoostAmount = jumpBoostAmount;
        }
    }
}