using System;
using UnityEngine;

namespace Assets.Model.Definitions.Player
{
    [Serializable]
    public struct StatDefinition
    {
        [SerializeField]
        private StatId _id;
        
        [SerializeField]
        private string _name;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private StatLevelDefinition[] _levels;

        public StatId Id => _id;

        public string Name => _name;

        public Sprite Icon => _icon;

        public StatLevelDefinition[] Levels => _levels;
    }
}
