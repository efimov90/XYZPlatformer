using Assets.PixelCrew.Creatures.Weapons;
using Assets.Utils;
using Assets.Utils.ObjectPool;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    public class DirectedProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private bool _useObjectPool;

        public GameObject ProjectilePrefab => _projectilePrefab;

        [ContextMenu("Launch Projectiles")]
        public void LaunchProjectiles()
        {
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            var instance =
                    _useObjectPool && _projectilePrefab.GetComponent<PoolItem>() != null
                        ? Pool.Instance.Get(_projectilePrefab, transform.position)
                        : SpawnUtils.Spawn(_projectilePrefab, transform.position);

            var projectile = instance.GetComponent<DirectionalProjectile>();

            var direction = new Vector2(Mathf.Cos(transform.rotation.z * Mathf.PI), Mathf.Sin(transform.rotation.z * Mathf.PI));

            projectile.Launch(direction);
        }
    }
}
