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
}
