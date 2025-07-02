using System;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [Serializable]
    public struct ThrowableItemDefinition
    {
        [InventoryId]
        [SerializeField]
        private string _id;

        [SerializeField]
        private GameObject _projectilePrefab;

        public string Id => _id;

        public GameObject ProjectilePrefab => _projectilePrefab;
    }
}
