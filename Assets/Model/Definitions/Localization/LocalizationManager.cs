using Assets.Model.Data.Properties;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Model.Definitions.Localization
{
    public class LocalizationManager
    {
        private StringPersistentProperty _currentLocale;

        public static readonly LocalizationManager Instance;

        private Dictionary<string, string> _localization = new Dictionary<string, string>();

        public event Action OnLocaleChanged;

        static LocalizationManager()
        {
            Instance = new LocalizationManager();
        }

        private LocalizationManager()
        {
            _currentLocale = new StringPersistentProperty("EN", "Localization/current");
            LoadLocale(_currentLocale.Value);
        }

        public string LocaleKey => _currentLocale.Value;

        private void LoadLocale(string localeToLoad)
        {
            var localeDefinition = Resources
                .Load<LocaleDefinition>($"Locales/{localeToLoad}");

            _localization = localeDefinition.GetData();
            _currentLocale.Value = localeToLoad;
            OnLocaleChanged?.Invoke();
        }

        public string Localize(string key) =>
            _localization.TryGetValue(key, out var value)
            ? value
            : $"%%%{key}%%%";

        public void SetLocale(string localeKey)
        {
            LoadLocale(localeKey);
        }
    }
}
