using System;
using UnityEngine;

namespace Assets.Model.Definitions.Repositories
{
    [Serializable]
    public struct ItemWithCount
    {
        [InventoryId]
        [SerializeField]
        private string _id;

        [SerializeField]
        private int _count;

        public string Id => _id;

        public int Count => _count;
    }
}
