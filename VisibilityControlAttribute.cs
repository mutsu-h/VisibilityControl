using System;
using UnityEngine;

public class VisibilityControlAttribute : PropertyAttribute
{
    //変数名を入れる
    public readonly string ValueName;
    //指定したい列挙子を入れる
    public readonly object EnumValue;
    //true それ以外の場合、
    public readonly bool SwapConditions;

    public VisibilityControlAttribute(string valueName, object enumValue = null, bool swapConditions = false)
    {
        this.ValueName = valueName;
        this.EnumValue = enumValue;
        this.SwapConditions = swapConditions;
    }
}
