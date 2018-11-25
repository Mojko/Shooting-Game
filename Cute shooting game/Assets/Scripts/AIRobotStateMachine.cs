using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AIRobotStateMachine : StateMachine<AIRobotStateMachine>
{
    public readonly AIRobotBehaviour behaviour;

    public AIRobotStateMachine(AIRobotBehaviour behaviour)
        : base()
    {
        this.behaviour = behaviour;
    }

    protected override void OnSetState(State<AIRobotStateMachine> state)
    {
        state.Start();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        this.behaviour.AvoidWalls();

        State<AIRobotStateMachine> state = this.GetState();
        state.Update();
    }

    public override void Register()
    {
        this.repository.Register<AIRobotStateMachine, StopState>(this);
        this.repository.Register<AIRobotStateMachine, AggressiveState>(this);
        this.repository.Register<AIRobotStateMachine, EscapeState>(this);
    }
}