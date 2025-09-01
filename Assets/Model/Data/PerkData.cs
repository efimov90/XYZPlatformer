using Assets.Model.Data.Properties;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Model.Data
{
    [Serializable]
    public class PerkData
    {
        [SerializeField]
        private StringProperty _used = new StringProperty();

        [SerializeField]
        private List<string> _unlocked;

        public StringProperty Used => _used;

        public void AddPerk(string id)
        {
            if (_unlocked.Contains(id))
            {
                return;
            }

            _unlocked.Add(id);
        }

        public bool IsUnlocked(string id)
            => _unlocked.Contains(id);
    }
}
