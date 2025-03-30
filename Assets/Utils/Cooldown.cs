using System;
using UnityEngine;

namespace Assets.Utils
{
    [Serializable]
    public class Cooldown
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
