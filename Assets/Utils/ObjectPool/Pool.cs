using System.Collections.Generic;
using UnityEngine;

namespace Assets.Utils.ObjectPool
{
    public class Pool : MonoBehaviour
    {
        private readonly Dictionary<int, Queue<PoolItem>> _poolItems = new Dictionary<int, Queue<PoolItem>>();

        private static Pool _instance;

        public static Pool Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("MainPool")
                        .AddComponent<Pool>();
                }

                return _instance;
            }
        }

        public GameObject Get(GameObject gameObject, Vector3 postition)
        {
            var id = gameObject.GetInstanceID();

            var queue = GetQueue(id);

            if (queue.Count > 0)
            {
                var pooledItem = queue.Dequeue();
                pooledItem.transform.position = postition;
                pooledItem.gameObject.SetActive(true);
                pooledItem.Restart();
                return pooledItem.gameObject;
            }

            var instance = SpawnUtils.Spawn(gameObject, postition, name);

            instance
                .GetComponent<PoolItem>()
                ?.Retain(id, this);

            return instance;
        }

        public void Release(int id, PoolItem poolItem)
        {
            var queue = GetQueue(id);
            queue.Enqueue(poolItem);
            poolItem.gameObject.SetActive(false);
        }

        private Queue<PoolItem> GetQueue(int id)
        {
            if (!_poolItems.TryGetValue(id, out var queue))
            {
                queue = new Queue<PoolItem>();
                _poolItems.Add(id, queue);
            }

            return queue;
        }
    }
}
