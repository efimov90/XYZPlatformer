using UnityEngine;

namespace Assets.Model.Data.Properties
{
    public class StringPersistentProperty : PrefsPersistantProperty<string>
    {
        public StringPersistentProperty(string defaultValue, string key)
            : base(defaultValue, key)
        {
            Init();
        }

        protected override string Load(string value)
            => PlayerPrefs.GetString(_key, value);

        protected override void Save(string propertyValue)
            => PlayerPrefs.SetString(_key, propertyValue);
    }
}
