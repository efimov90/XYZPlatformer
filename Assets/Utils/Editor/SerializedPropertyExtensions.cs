using System;
using UnityEditor;

namespace Assets.Utils.Editor
{
    public static class SerializedPropertyExtensions
    {
        public static bool TryGetEnum<TEnum>(this SerializedProperty serializedProperty, out TEnum value)
            where TEnum : Enum
        {
            value = default;

            if (serializedProperty.propertyType != SerializedPropertyType.Enum)
            {
                return false;
            }

            var names = serializedProperty.enumNames;

            if (names == null || names.Length == 0)
            {
                return false;
            }

            var enumName = names[serializedProperty.enumValueIndex];

            value = (TEnum)Enum.Parse(typeof(TEnum), enumName);
            return true;
        }
    }
}
