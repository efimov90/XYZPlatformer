using Assets.CommonComponents.UI.Widgets;
using Assets.Model.Definitions.Localization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CommonComponents.UI.Windows.Localization
{
    public class LocalizationWindow : AnimatedWindow
    {
        public DataGroup<LocaleInfo, LocaleItemWidget> _localeDataGroup;

        [SerializeField]
        private Transform _container;

        [SerializeField]
        private LocaleItemWidget _prefab;

        private string[] _supportedLocales =
        {
            "EN",
            "RU"
        };

        protected override void Start()
        {
            base.Start();

            _localeDataGroup = new DataGroup<LocaleInfo, LocaleItemWidget>(_prefab, _container);
            _localeDataGroup.SetData(ComposeData());
        }

        private List<LocaleInfo> ComposeData() =>
            _supportedLocales
                .Select(locale => new LocaleInfo { LocaleId = locale })
                .ToList();

        public void OnSelected(string selectedLocale)
        {
            LocalizationManager.Instance.SetLocale(selectedLocale);
        }
    }
}
