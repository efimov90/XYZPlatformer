using Assets.Model.Data;
using System;
using UnityEngine;

namespace Assets.Model
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField]
        private InventoryData _inventory;

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
