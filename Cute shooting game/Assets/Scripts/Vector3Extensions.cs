using UnityEngine;
using System.Collections;

public static class Vector3Extensions
{
    public static Quaternion ToQuaternion(this Vector3 @this)
    {
        return Quaternion.Euler(@this.x, @this.y, @this.z);
    }
}