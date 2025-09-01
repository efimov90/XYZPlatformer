using Assets.Utils;
using Assets.Utils.ObjectPool;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    public class AdjustableSpawnComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private bool _useObjectPool;

        public GameObject Spawn()
        {
            if (_spawnPoint == null)
            {
                Debug.LogError("Spawn point is not set.");
                return null;
            }

            if (_prefab == null)
            {
                Debug.LogError("Prefab is not set.");
                return null;
            }

            var newInstance =
                _useObjectPool && _prefab.GetComponent<PoolItem>() != null
                    ? Pool.Instance.Get(_prefab, _spawnPoint.position)
                    : SpawnUtils.Spawn(_prefab, _spawnPoint.position);

            newInstance.transform.localScale = _spawnPoint.lossyScale;
            newInstance.SetActive(true);

            return newInstance;
        }

        public void SetPrefab(GameObject projectilePrefab)
        {
            _prefab = projectilePrefab;
        }
    }
}
