using Assets.Utils;
using Assets.Utils.ObjectPool;
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
            SpawnObject spawnObject = null;

            foreach (var item in _spawnObjects)
            {
                if(item.Name == name)
                {
                    spawnObject = item;
                    break;
                }
            }

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