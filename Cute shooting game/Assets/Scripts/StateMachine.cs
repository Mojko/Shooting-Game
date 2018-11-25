using System;
using UnityEngine;
using UnityEngine.Events;

public class StateMachine<TStateMachine> : IStateRepository
    where TStateMachine : StateMachine<TStateMachine>
{
    private State<TStateMachine> state;
    private bool hasDoneEvent;
    private Func<bool> canDoEventAgainWhen;
    private SetStateUntilDelegate<Func<bool>, State<TStateMachine>> setStateUntil;
    public StateRepository repository;

    public delegate TReturn SetStateUntilDelegate<TReturn, TOut>(out TOut @out);

    public StateMachine()
    {
        this.repository = new StateRepository();
        this.Register();
    }

    public virtual void UpdateState()
    {
        if (this.hasDoneEvent)
        {
            this.hasDoneEvent = !canDoEventAgainWhen();
        }

        if(this.setStateUntil != null)
        {
            State<TStateMachine> state;
            bool flag = this.setStateUntil
                .Invoke(out state)
                .Invoke();

            if (flag)
            {
                this.SetState(state);
            }
        }
    }

    protected virtual void OnSetState(State<TStateMachine> state)
    {

    }

    public void SetState(State<TStateMachine> state)
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

    public void SetStateUntil(State<TStateMachine> state, SetStateUntilDelegate<Func<bool>, State<TStateMachine>> predicate)
    {
        this.SetState(state);
        this.setStateUntil = predicate;
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

    public State<TStateMachine> GetState()
    {
        return this.state;
    }

    public virtual void Register()
    {
    }

    public TState Resolve<TState>()
    {
        return this.repository.Resolve<TState>();
    }
}