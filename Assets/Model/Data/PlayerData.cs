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

        public InventoryData Inventory => _inventory;

        public int Health;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
