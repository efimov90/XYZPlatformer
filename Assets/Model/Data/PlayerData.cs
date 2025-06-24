using System;
using UnityEngine;

namespace Assets.Model
{
    [Serializable]
    public class PlayerData
    {
        public int Money;
        public int Health;
        public bool IsArmed;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
