using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Model.Definitions.Editor
{
    [CustomPropertyDrawer(typeof(InventoryIdAttribute))]
    public class InventoryIdAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var definitions = DefinitionsFacade.Instance.InventoryItemDefinitions.ItemsForEditor;

            var ids = definitions
                .Select(item => item.Id)
                .ToArray();

            var index = Mathf.Max(Array.IndexOf(ids, property.stringValue), 0);

            var newIndex = EditorGUI.Popup(position, property.displayName, index, ids);
            property.stringValue = ids[newIndex];
        }
    }
}
