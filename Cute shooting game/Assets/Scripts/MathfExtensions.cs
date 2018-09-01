using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathfExtensions
{
    public static float Choose(this Mathf @this, params float[] values)
    {
        int index = Random.Range(0, values.Length);
        return values[index];
    }
}
