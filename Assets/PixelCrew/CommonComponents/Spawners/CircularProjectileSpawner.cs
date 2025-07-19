using Assets.PixelCrew.Creatures.Weapons;
using Assets.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    public class CircularProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        private CirculaprojectileSettings[] _settings;

        public int Stage { get; set; }

        [ContextMenu("Launch Projectiles")]
        public void LaunchProjectiles()
        {
            StartCoroutine(SpawnProjectiles());
        }

        private IEnumerator SpawnProjectiles()
        {
            var settings = _settings[Stage];

            var sectorStep = 2 * Mathf.PI / settings.ProjectilesCount;
            for (int i = 0; i < settings.ProjectilesCount; i++)
            {
                var angle = sectorStep * i;
                var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                var instance = SpawnUtils.Spawn(settings.ProjectilePrefab, transform.position);

                var projectile = instance.GetComponent<DirectionalProjectile>();

                projectile.Launch(direction);

                yield return new WaitForSeconds(settings.Delay);
            }
        }
    }
}
