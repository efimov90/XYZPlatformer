using System;
using UnityEngine.Events;

namespace Assets.PixelCrew.CommonComponents.Health
{
    [Serializable]
    public class HealthChanged : UnityEvent<int>
    {
        public HealthChanged()
        {

        }

        public HealthChanged(int health)
        {
            Health = health;
        }

        public int Health { get; }
    }
}