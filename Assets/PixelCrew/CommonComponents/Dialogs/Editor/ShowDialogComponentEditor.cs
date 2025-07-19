using Assets.Utils.Editor;
using UnityEditor;

namespace Assets.PixelCrew.CommonComponents.Dialogs.Editor
{
    [CustomEditor(typeof(ShowDialogComponent))]
    public class ShowDialogComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty _modeProperty;
        private SerializedProperty _onExitedProperty;

        private void OnEnable()
        {
            _modeProperty = serializedObject.FindProperty(ShowDialogComponent.EditorModePropertyName);
            _onExitedProperty = serializedObject.FindProperty(ShowDialogComponent.EditorOnExitedPropertyName);
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

            EditorGUILayout.PropertyField(_onExitedProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
