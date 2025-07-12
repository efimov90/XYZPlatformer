using Assets.Model.Definitions.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Localization
{
    [RequireComponent(typeof(Text))]
    public class LocalizeText : MonoBehaviour
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private bool _upperCase;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            LocalizationManager.Instance.OnLocaleChanged += OnLocaleChanged;
            Localize();
        }

        private void OnLocaleChanged()
        {
            Localize();
        }

        private void Localize()
        {
            var localizedText = LocalizationManager.Instance.Localize(_key);

            _text.text = _upperCase ? localizedText.ToUpper() : localizedText;
        }

        private void OnDestroy()
        {
            if (LocalizationManager.Instance != null)
            {
                LocalizationManager.Instance.OnLocaleChanged -= OnLocaleChanged;
            }
        }
    }
}
