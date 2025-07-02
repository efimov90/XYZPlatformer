using Assets.Model.Data.Dialogs;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/Dialog", fileName = "Dialog")]
    public class DialogDefinition : ScriptableObject
    {
        [SerializeField]
        private DialogData _dialogData;

        public DialogData DialogData => _dialogData;
    }
}
