using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Assets.PixelCrew.CommonComponents
{
    public class ChangeLightsComponent : MonoBehaviour
    {
        [SerializeField]
        private Light2D[] _light;

        [ColorUsage(true, true)]
        [SerializeField]
        private Color _color;

        [ContextMenu("Set Color")]
        public void SetColor()
        {
            foreach (var light in _light)
            {
                light.color = _color;
            }
        }
    }
}
