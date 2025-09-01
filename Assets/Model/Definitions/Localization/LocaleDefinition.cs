using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Model.Definitions.Localization
{
    [CreateAssetMenu(menuName = "Localization/LocaleDefinition", fileName = "LocaleDefinition")]
    public partial class LocaleDefinition : ScriptableObject
    {
        [SerializeField]
        private string _url;

        [SerializeField]
        private List<LocaleItem> _localeItems = new List<LocaleItem>();

        private UnityWebRequest _request;

        public Dictionary<string, string> GetData()
        {
            var dictionary = new Dictionary<string, string>();

            foreach (var localeItem in _localeItems)
            {
                dictionary.Add(localeItem.Key, localeItem.Value);
            }

            return dictionary;
        }

        [ContextMenu("Update Locals")]
        public void LoadLocals()
        {
            if (_request != null)
            {
                return;
            }

            _request = UnityWebRequest.Get(_url);

            _request.SendWebRequest().completed += OnDataLoaded;
        }

        private void OnDataLoaded(AsyncOperation operation)
        {
            if (operation.isDone)
            {
                var rows = _request.downloadHandler.text
                    .Split('\n')
                    .Where(row => !string.IsNullOrWhiteSpace(row));

                _localeItems.Clear();

                foreach (var row in rows)
                {
                    if (string.IsNullOrWhiteSpace(row))
                    {
                        continue;
                    }

                    AddLocaleItem(row);
                }
            }
        }

        private void AddLocaleItem(string row)
        {
            try
            {
                var pair = row.Split('\t');

                if (string.IsNullOrWhiteSpace(pair[1].Trim()))
                {
                    return;
                }

                _localeItems.Add(new LocaleItem
                {
                    Key = pair[0].Trim(),
                    Value = pair[1].Trim()
                });
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to parse locale item: {row}. Error: {e.Message}");
                throw;
            }
        }
    }
}
