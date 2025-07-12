using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Cooldowns
{
    public class CooldownComponent : MonoBehaviour
    {
        [SerializeField]
        private float _duration;

        private float _timeUntilReady;

        public void Reset()
        {
            _timeUntilReady = Time.time + _duration;
        }

        public bool IsReady => _timeUntilReady <= Time.time;
    }
}
