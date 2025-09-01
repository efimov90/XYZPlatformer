using Assets.Model.Data;
using Assets.Model.Data.Properties;
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

        public IntProperty Health = new IntProperty();

        public PerkData Perks = new PerkData();
        public LevelData Levels = new LevelData();

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
