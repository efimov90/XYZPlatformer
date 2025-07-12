using System;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    [Serializable]
    public class SpawnObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private Transform _target;
        public string Name => _name;
        public GameObject Prefab => _prefab;
        public Transform Target => _target;
    }
}