using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T>
{
    private T state;

    protected abstract void OnSetState();

    public void SetState(T state)
    {
        this.state = state;
    }

    public T GetState()
    {
        return this.state;
    }
}