using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHelper
{
    private float time;
    private TimeType type;

    public TimeHelper(float time, TimeType type)
    {
        this.type = type;
    }

    public float ToMilliseconds()
    {
        switch (this.type)
        {
            case TimeType.Seconds:
                return this.time * 1000;
        }

        return -1;
    }
}


public enum TimeType
{
    Seconds
}