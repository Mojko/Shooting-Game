using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework.Internal.Execution;
using UnityEngine;
using System.Threading;

public class Timer
{
    /*private float time;
    private TimeType timeType;
    
    public Timer(float time, TimeType timeType)
    {
        this.time = time;
        this.timeType = timeType;
        ThreadPool.QueueUserWorkItem(Update, this);
    }

    private void Update(object o)
    {
        Timer @this = (Timer) o;
        while (@this.time > 0)
        {
            switch(@this.timeType)
            {
                case TimeType.Seconds:
                    TimeHelper.TickSeconds(@this.time);
                    break;
            }  
        }
    }*/
}
//private int time;
    
    
    
/*
private int time;
private int startTime;
private Thread thread;

public delegate void EndDelegate();

private EndDelegate endMethod;

public Timer(EndDelegate endMethod, int milliseconds)
{
    this.time = milliseconds;
    this.startTime = milliseconds;
    this.endMethod = endMethod;

    ThreadPool.QueueUserWorkItem(Update, this);
}

private void Update(object state)
{
    while (true)
    {
        Timer @this = (Timer)state;
    
        Debug.Log("Update: " + time);
        @this.time--;
         if (time <= 0)
         {
             @this.endMethod.Invoke();
             break;
         }
    }
}
*/
