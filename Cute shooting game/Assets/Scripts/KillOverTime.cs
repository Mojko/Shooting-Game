using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOverTime : MonoBehaviour
{
    public float time;

    private void Update()
    {
        time -= 1 * Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
