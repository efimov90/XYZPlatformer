using System;
using UnityEngine;

namespace Assets.Model.Definitions.Repositories
{
    [Serializable]
    public struct PerkDefinition : IHaveId
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private string _information;

        [SerializeField]
        private ItemWithCount _price;

        [SerializeField]
        private float _cooldown;

        public string Id => _id;

        public Sprite Icon => _icon;

        public string Information => _information;

        public ItemWithCount Price => _price;

        public float Cooldown => _cooldown;
    }
}
