using System;
using UnityEngine;

namespace Assets.Model.Data.Dialogs
{
    [Serializable]
    public class DialogData
    {
        [SerializeField]
        private string[] _sentences;

        public string[] Sentences => _sentences;
    }
}
