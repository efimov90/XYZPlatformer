using System;
using UnityEngine;

namespace Assets.Model.Data.Properties
{
    [Serializable]
    public class FloatPersistentProperty : PrefsPersistantProperty<float>
    {
        public FloatPersistentProperty(float defaultValue, string key)
            : base(defaultValue, key)
        {
            Init();
        }

        protected override float Load(float defaultValue)
            => PlayerPrefs.GetFloat(_key, defaultValue);

        protected override void Save(float propertyValue)
        {
            PlayerPrefs.SetFloat(_key, propertyValue);
            PlayerPrefs.Save();
        }
    }
}
