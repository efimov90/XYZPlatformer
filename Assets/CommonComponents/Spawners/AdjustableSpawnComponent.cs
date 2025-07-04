using UnityEngine;

namespace Assets.CommonComponents.Spawners
{
    public class AdjustableSpawnComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private GameObject _prefab;

        public void Spawn()
        {
            if (_spawnPoint == null)
            {
                Debug.LogError("Spawn point is not set.");
                return;
            }

            if (_prefab == null)
            {
                Debug.LogError("Prefab is not set.");
                return;
            }

            var newInstance = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            newInstance.transform.localScale = _spawnPoint.lossyScale;
            newInstance.SetActive(true);

            return;
        }

        public void SetPrefab(GameObject projectilePrefab)
        {
            _prefab = projectilePrefab;
        }
    }
}
