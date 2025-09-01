using UnityEngine;

namespace Assets.Utils
{
    public class SpawnUtils
    {
        private const string ContainerName = "Spawned";

        public static GameObject Spawn(GameObject prefab, Vector3 position, string containerName = ContainerName)
        {
            var container = GameObject.Find(containerName)
                ?? new GameObject(ContainerName);

            return Object.Instantiate(prefab, position, Quaternion.identity, container.transform);
        }
    }
}
