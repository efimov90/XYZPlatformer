using System;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [Serializable]
    public struct ItemDefinition
    {
        [SerializeField]
        private string _id;

        public string Id => _id;

        public bool IsDefault => string.IsNullOrEmpty(_id);
    }
}