using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(VisibilityControlAttribute))]
public class VisibilityControlDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if(!DisplayInInspectorWindowCheck(base.attribute as VisibilityControlAttribute, property))
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
            Debug.LogError("適切な変数名を入力してください");
        }
        else
        {
            //変数の型の比較
            if (prop.propertyType == SerializedPropertyType.Boolean)
            {
                if (prop.boolValue) return true;
            }
            else if (prop.propertyType == SerializedPropertyType.Enum)
            {
                if (attr.SwapConditions)
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
                Debug.LogError("列挙型かbool型を使用してください");
            }
        }

        return false;
    }
}
