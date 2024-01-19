using System;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(VisibilityControlAttribute))]
public class VisibilityControlDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!DisplayInInspectorWindowCheck(base.attribute as VisibilityControlAttribute, property))
            return;

        EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (DisplayInInspectorWindowCheck(base.attribute as VisibilityControlAttribute, property))
            return EditorGUI.GetPropertyHeight(property, label, true);

        return -EditorGUI.GetPropertyHeight(property, label, true);
    }

    //true で表示
    //false なら非表示
    private bool DisplayInInspectorWindowCheck(VisibilityControlAttribute attr, SerializedProperty property)
    {
        var prop = property.serializedObject.FindProperty(attr.ValueName);

        if (prop == null)
        {
            Debug.LogError($"VisibilityControlAttributeの引数に適切な変数名を入力してください\n'{attr.ValueName}' は存在しないもしくは使用できません\n<English>\nPlease input an appropriate variable name for the argument of VisibilityControlAttribute\nCannot find or use '{attr.ValueName}' property \n");
        }
        else
        {
            //変数の型の比較
            if (prop.propertyType == SerializedPropertyType.Boolean)
            {
                if (attr.ReverseConditions)
                {
                    if (!prop.boolValue) return true;
                }
                else
                {
                    if (prop.boolValue) return true;
                }
            }
            else if (prop.propertyType == SerializedPropertyType.Enum)
            {
                if (attr.EnumValue != null &&
                    attr.EnumValue.GetType().IsEnum)
                {
                    if (attr.ReverseConditions)
                    {
                        if ((int)attr.EnumValue != prop.enumValueIndex) return true;
                    }
                    else
                    {
                        //比較
                        if ((int)attr.EnumValue == prop.enumValueIndex) return true;
                    }
                }
                else
                {
                    Debug.LogError("引数には列挙子を指定してください\n<English>\nPlease specify an enumerator as the argument \n");
                }
            }
            else
            {
                Debug.LogError("列挙型かbool型を使用してください\n<English>\nPlease use an enum type or a bool type \n");
            }
        }

        return false;
    }
}
