using UnityEngine;

namespace Assets.Utils
{
    public static class GameObjectExtensions
    {
        public static bool IsInLayer(this GameObject gameObject, LayerMask layerMask)
            => layerMask == (layerMask | 1 << gameObject.layer);
    }
}
