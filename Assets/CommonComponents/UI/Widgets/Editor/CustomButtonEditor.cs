using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Assets.CommonComponents.UI.Widgets.Editor
{
    [CustomEditor(typeof(CustomButton), true)]
    [CanEditMultipleObjects]
    public class CustomButtonEditor : ButtonEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(CustomButton.NormalStateFieldName), new GUIContent("Normal state label"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(CustomButton.PressedStateFieldName), new GUIContent("Pressed state label"));
            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}