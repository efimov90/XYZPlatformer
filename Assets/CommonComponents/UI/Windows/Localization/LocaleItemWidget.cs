using Assets.Model.Definitions.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CommonComponents.UI.Windows.Localization
{
    public class LocaleItemWidget : MonoBehaviour, IItemRenderer<LocaleInfo>
    {
        [SerializeField]
        private Text _text;

        [SerializeField]
        private GameObject _selector;

        [SerializeField]
        private SelectLocale _onSelect;

        private LocaleInfo _localeInfo;

        private void Start()
        {
            LocalizationManager.Instance.OnLocaleChanged += UpdateSelection;
        }

        private void UpdateSelection()
        {
            _selector.SetActive(LocalizationManager.Instance.LocaleKey == _localeInfo.LocaleId);
        }

        public void SetData(LocaleInfo localeInfo, int index)
        {
            _localeInfo = localeInfo;
            UpdateSelection();
            _text.text = localeInfo.LocaleId.ToUpper();
        }

        public void OnSelected()
        {
            _onSelect?.Invoke(_localeInfo.LocaleId);
        }

        private void OnDestroy()
        {
            if (LocalizationManager.Instance != null)
            {
                LocalizationManager.Instance.OnLocaleChanged -= UpdateSelection;
            }
        }
    }
}
