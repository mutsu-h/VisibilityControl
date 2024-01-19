using System;
using UnityEngine;

public class VisibilityControlAttribute : PropertyAttribute
{
    //変数名を入れる
    public readonly string ValueName;
    //指定したい列挙子を入れる
    public readonly object EnumValue;
    //条件の反転、
    public readonly bool ReverseConditions;

    public VisibilityControlAttribute(string valueName, object enumValue = null, bool ReverseConditions = false)
    {
        this.ValueName = valueName;
        this.EnumValue = enumValue;
        this.ReverseConditions = ReverseConditions;
    }
}
