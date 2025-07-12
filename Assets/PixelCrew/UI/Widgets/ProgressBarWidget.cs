using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Widgets
{
    public class ProgressBarWidget : MonoBehaviour
    {
        [SerializeField]
        private Image _progressBarImage;

        public void SetProgress(float progress)
        {
            if (_progressBarImage == null)
            {
                Debug.LogError("ProgressBarImage is not assigned.");
                return;
            }

            _progressBarImage.fillAmount = progress;
        }
    }
}
