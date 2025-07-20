using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    public class DirectedProjectileSpawnersLauncher : MonoBehaviour
    {
        private DirectedProjectileSpawner[] _spawners;

        [SerializeField]
        public GameObject _container;

        private void Awake()
        {
            _spawners = _container.GetComponentsInChildren<DirectedProjectileSpawner>();
        }

        [ContextMenu("Launch Projectiles")]
        public void LaunchProjectiles()
        {
            SpawnProjectiles();
        }

        private void SpawnProjectiles()
        {
            foreach (var spawner in _spawners)
            {
                spawner.LaunchProjectiles();
            }
        }
    }
}
