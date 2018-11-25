using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class StateRepository
{
    private readonly Dictionary<Type, object> states;

    public StateRepository()
    {
        states = new Dictionary<Type, object>();
    }

    public void Register<TStateMachine, TState>(TStateMachine stateMachine)
    {
        Type type = typeof(TState);
        TState state = (TState)Activator.CreateInstance(type, stateMachine);
        states.Add(type, state);
    }

    public TState Resolve<TState>()
    {
        return (TState)states[typeof(TState)];
    }
}
