using Unity.Mathematics;
using UnityEngine;

public static class ColorUtils
{
    public static Color FromFloat4(float4 values)
    {
        return new Color(values.x, values.y, values.z, values.w);    
    }
    
    public static float4 ToFloat4(this Color color)
    {
        return new float4(color.r, color.g, color.b, color.a);
    }
}