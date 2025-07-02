using System;
using System.Linq;
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
        private ItemTag[] _itemTags;

        public string Id => _id;

        public bool IsDefault => string.IsNullOrEmpty(_id);

        public Sprite Icon => _icon;

        public ItemTag[] ItemTags => _itemTags;

        public bool HasTag(ItemTag tag) => _itemTags.Contains(tag);
    }
}