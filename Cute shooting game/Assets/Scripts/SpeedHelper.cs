using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeedHelper
{
    /// <summary>
    /// Slows down an entity by a certain amount of percentage per step until it reaches 0.
    /// </summary>
    /// <param name="val"></param>
    /// <param name="max"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public static float Slow(float val, float max, float percentage)
    {
        val -= max * percentage;
        return val;
    }
}
