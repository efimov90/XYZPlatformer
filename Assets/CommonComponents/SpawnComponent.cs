using UnityEngine;

namespace Assets.CommonComponents
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var newInstance = Instantiate(_prefab, _target.position, Quaternion.identity);
            newInstance.transform.localScale = _target.lossyScale;
        }
    }
}