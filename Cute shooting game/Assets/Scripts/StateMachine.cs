using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachine<T>
{
    private T state;
    private bool hasDoneEvent;
    private Func<bool> canDoEventAgainWhen;

    public virtual void UpdateState()
    {
        if (this.hasDoneEvent)
        {
            this.hasDoneEvent = !canDoEventAgainWhen();
        }
    }

    protected virtual void OnSetState(T state)
    {

    }

    public void SetState(T state)
    {
        if(this.state != null)
        {
            if(this.state.Equals(state))
            {
                return;
            }
        }

        this.state = state;
        this.OnSetState(state);
    }

    public void DoEventOnce(UnityAction predicate, Func<bool> canDoEventAgainWhen)
    {
        if (!hasDoneEvent)
        {
            predicate.Invoke();
            hasDoneEvent = true;
            this.canDoEventAgainWhen = canDoEventAgainWhen;
        }
    }

    public T GetState()
    {
        return this.state;
    }
}