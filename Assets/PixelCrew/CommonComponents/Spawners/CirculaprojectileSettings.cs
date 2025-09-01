using System;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    [Serializable]
    public struct CirculaprojectileSettings
    {
        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private int _projectilesCount;

        [SerializeField]
        private float _delay;

        public GameObject ProjectilePrefab => _projectilePrefab;
        public int ProjectilesCount => _projectilesCount;
        public float Delay => _delay;
    }
}
