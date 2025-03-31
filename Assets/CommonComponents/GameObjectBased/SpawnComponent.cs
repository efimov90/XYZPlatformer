using System.Linq;
using UnityEngine;

namespace Assets.CommonComponents.GameObjectBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private SpawnObject[] _spawnObjects;

        public void Spawn(string name)
        {
            var spawnObject = _spawnObjects
                .FirstOrDefault(x => x.Name == name);

            if(spawnObject is null)
            {
                Debug.LogError($"SpawnObject with name {name} not found");

                return;
            }

            var newInstance = Instantiate(spawnObject.Prefab, spawnObject.Target.position, Quaternion.identity);
            newInstance.transform.localScale = spawnObject.Target.lossyScale;
        }
    }
}