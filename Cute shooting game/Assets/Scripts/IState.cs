using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<TStateMachine> 
    where TStateMachine : StateMachine<State<TStateMachine>>
{
    protected readonly TStateMachine stateMachine;

    public State(TStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public abstract void Update();
    public abstract void OnSet();
}
