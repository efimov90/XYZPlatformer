using System;
using UnityEngine;

namespace Assets.Model.Definitions.Localization
{
    public partial class LocaleDefinition
    {
        [Serializable]
        private class LocaleItem
        {
            [SerializeField]
            private string _key;

            [SerializeField]
            private string _value;

            public string Key
            {
                get => _key;
                set => _key = value;
            }

            public string Value
            {
                get => _value;
                set => _value = value;
            }
        }
    }
}
