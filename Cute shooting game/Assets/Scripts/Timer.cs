using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public float time;
	private float originalTime;

	private bool tick = false;
	private OnFinish onFinish;
    private int timesStarted;
    private OnFinish almostFinish;

	public delegate void OnFinish();

	public virtual void StartTimer(OnFinish onFinish = null, OnFinish almostFinish = null, bool startImmediatly = false)
	{
        if (this.IsStarted())
        {
            return;
        }

		if (this.time > 0)
		{
			this.originalTime = this.time; 
		}
		else
		{
            if (!startImmediatly)
            {
                this.time = this.originalTime;
            }
			else
            {
                this.time = 0;
            }
		}

		this.tick = true;
		this.onFinish = onFinish;
        this.almostFinish = almostFinish;
        this.timesStarted++;
	}

    public bool IsStarted()
    {
        return tick;
    }

    private void Update()
	{
		if (tick)
		{
			this.time -= 1 * Time.deltaTime;
            
            if(this.time < 0.2f)
            {
                if(this.almostFinish != null)
                {
                    this.almostFinish.Invoke();
                }
            }

			if (this.IsFinished())
			{
				this.Stop();
			}
		}
	}

	public void Reset()
	{
		this.time = this.originalTime;
	}

	public float GetOriginalTime()
	{
		return originalTime;
	}

	public bool IsFinished()
	{
		return (this.time <= 0 || this.originalTime <= 0 || tick == false);
	}

	public void Stop()
	{
		this.tick = false;
		this.time = this.originalTime;
		if (this.onFinish != null)
		{
			this.onFinish.Invoke();
		}        
	}

    public int GetTimesStarted()
    {
        return this.timesStarted;
    }

    public float GetPercentage()
    {
        return this.time / this.originalTime;
    }
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