using Assets.Utils.Editor;
using UnityEditor;

namespace Assets.CommonComponents.Dialogs.Editor
{
    [CustomEditor(typeof(ShowDialogComponent))]
    public class ShowDialogComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty _modeProperty;

        private void OnEnable()
        {
            _modeProperty = serializedObject.FindProperty(ShowDialogComponent.EditorModePropertyName);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(_modeProperty);

            if (_modeProperty.TryGetEnum(out ShowDialogComponent.Mode mode))
            {
                switch (mode)
                {
                    case ShowDialogComponent.Mode.Bound:
                        EditorGUILayout.PropertyField(serializedObject.FindProperty(ShowDialogComponent.EditorBoundPropertyName));
                        break;

                    case ShowDialogComponent.Mode.External:
                        EditorGUILayout.PropertyField(serializedObject.FindProperty(ShowDialogComponent.EditorExternalPropertyName));
                        break;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
