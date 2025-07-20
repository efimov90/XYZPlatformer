using Assets.PixelCrew.CommonComponents.Spawners;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Bosses
{
    public class DavidTheCrabby : MonoBehaviour
    {
        [SerializeField]
        private DirectedProjectileSpawnersLauncher _leftLauncher;

        [SerializeField]
        private DirectedProjectileSpawnersLauncher _rightLauncher;

        [SerializeField]
        private DirectedProjectileSpawnersLauncher _topLauncher;

        public void SpawnLeftProjectiles()
        {
            _leftLauncher.LaunchProjectiles();
        }

        public void SpawnRightProjectiles()
        {
            _rightLauncher.LaunchProjectiles();
        }

        public void SpawnTopProjectiles()
        {
            _topLauncher.LaunchProjectiles();
        }

        public void SpawnSidesProjectiles()
        {
            SpawnLeftProjectiles();
            SpawnRightProjectiles();
        }
    }
}
