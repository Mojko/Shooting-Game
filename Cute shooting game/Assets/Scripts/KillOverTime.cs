using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOverTime : MonoBehaviour
{
    public float time;
    private float originalTime;

    private void Start()
    {
        this.originalTime = this.time;
    }

    private void Update()
    {
        time -= 1 * Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public float GetOriginalTime()
    {
        return this.originalTime;//new TimeHelper(this.originalTime, TimeType.Seconds);
    }
}
