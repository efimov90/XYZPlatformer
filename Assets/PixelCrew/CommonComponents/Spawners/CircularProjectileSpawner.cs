using Assets.PixelCrew.Creatures.Weapons;
using Assets.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    public class CircularProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private int _projectilesCount;

        [SerializeField]
        private float _delay;

        [ContextMenu("Launch Projectiles")]
        public void LaunchProjectiles()
        {
            StartCoroutine(SpawnProjectiles());
        }

        private IEnumerator SpawnProjectiles()
        {
            var sectorStep = 2 * Mathf.PI / _projectilesCount;
            for (int i = 0; i < _projectilesCount; i++)
            {
                var angle = sectorStep * i;
                var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                var instance = SpawnUtils.Spawn(_projectilePrefab, transform.position);

                var projectile = instance.GetComponent<DirectionalProjectile>();

                projectile.Launch(direction);

                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
