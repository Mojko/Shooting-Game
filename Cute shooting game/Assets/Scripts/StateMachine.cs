using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T>
{
    private T state;

    public abstract void UpdateState();

    protected virtual void OnSetState(T state)
    {

    }

    public void SetState(T state)
    {
        this.state = state;
        this.OnSetState(state);
    }

    public T GetState()
    {
        return this.state;
    }
}