using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private T state;

    public virtual void UpdateState()
    {

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

    public T GetState()
    {
        return this.state;
    }
}