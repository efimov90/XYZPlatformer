using Assets.Utils;
using Assets.Utils.ObjectPool;
using System.Linq;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Spawners
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField]
        private SpawnObject[] _spawnObjects;

        [SerializeField]
        private bool _useObjectPool;

        public GameObject Spawn(string name)
        {
            var spawnObject = _spawnObjects
                .FirstOrDefault(x => x.Name == name);

            if (spawnObject is null)
            {
                Debug.LogError($"SpawnObject with name {name} not found");

                return null;
            }

            var newInstance =
                _useObjectPool && spawnObject.Prefab.GetComponent<PoolItem>() != null
                    ? Pool.Instance.Get(spawnObject.Prefab, spawnObject.Target.position)
                    : SpawnUtils.Spawn(spawnObject.Prefab, spawnObject.Target.position);

            newInstance.transform.localScale = spawnObject.Target.lossyScale;
            newInstance.gameObject.SetActive(true);

            return newInstance;
        }
    }
}