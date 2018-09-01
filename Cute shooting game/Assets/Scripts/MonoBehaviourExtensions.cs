using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonoBehaviourExtensions
{
    public static void Enable(this MonoBehaviour @this)
    {
        @this.enabled = true;
    }

    public static void Disable(this MonoBehaviour @this)
    {
        @this.enabled = false;
    }
}
