using Assets.PixelCrew.UI.Hud.Dialogs;
using Assets.Model.Data.Dialogs;
using Assets.Model.Definitions;
using System;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Dialogs
{
    public partial class ShowDialogComponent : MonoBehaviour
    {
#if UNITY_EDITOR
        public const string EditorModePropertyName = nameof(_mode);
        public const string EditorBoundPropertyName = nameof(_bound);
        public const string EditorExternalPropertyName = nameof(_external);
#endif

        [SerializeField]
        private Mode _mode;

        [SerializeField]
        private DialogData _bound;

        [SerializeField]
        private DialogDefinition _external;

        private DialogBoxController _dialogBox;

        public DialogData DialogData
        {
            get
            {
                switch (_mode)
                {
                    case Mode.Bound:
                        return _bound;
                    case Mode.External:
                        return _external.DialogData;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_mode));
                }
            }
        }

        public void Show()
        {
            if (_dialogBox == null)
            {
                _dialogBox = FindObjectOfType<DialogBoxController>();
            }

            _dialogBox.ShowDialog(DialogData);
        }

        public void Show(DialogDefinition data)
        {
            _external = data;

            Show();
        }
    }
}
