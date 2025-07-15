using Assets.Model.Definitions.Repositories;
using System;
using UnityEngine;

namespace Assets.Model.Definitions.Player
{
    [Serializable]
    public struct StatLevel
    {
        [SerializeField]
        private float _value;

        [SerializeField]
        private ItemWithCount _price;

        public float Value => _value;

        public ItemWithCount Price => _price;
    }
}
