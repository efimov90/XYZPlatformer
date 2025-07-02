using System;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [Serializable]
    public struct ItemDefinition
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private bool _isStackable;

        public string Id => _id;

        public bool IsDefault => string.IsNullOrEmpty(_id);

        public Sprite Icon => _icon;

        public bool IsStackable => _isStackable;
    }
}