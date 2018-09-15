using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathHelper 
{
    public static float Choose(params float[] values)
    {
        int index = Random.Range(0, values.Length);
        return values[index];
    }

    public static float Reverse(float value, float min, float max)
    {
        return (value / max);
    }

    public static float RemapValue(float value, float low1, float high1, float low2, float high2)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }
}
