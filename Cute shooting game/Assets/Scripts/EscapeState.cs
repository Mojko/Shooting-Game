using System;
using UnityEngine;

public class EscapeState : State<AIRobotStateMachine>
{
    public EscapeState(AIRobotStateMachine subject)
        : base(subject)
    {
    }

    public override void Start()
    {
        this.stateMachine.behaviour.Move();
    }

    public override void Update()
    {
        this.stateMachine.behaviour.RotateTowards(this.stateMachine.behaviour.target);

        Vector3 destination = Vector3.zero;

        if(!this.stateMachine.behaviour.AvoidWalls())
        {
            destination = this.stateMachine.behaviour.transform.position
                - this.stateMachine.behaviour.transform.forward
                - this.stateMachine.behaviour.transform.right
                * MathHelper.GetSide(this.stateMachine.behaviour.transform, this.stateMachine.behaviour.target)
                * 1.5f;
        }

        if (this.stateMachine.behaviour.IsTargetTooFarAwayCalculation(this.stateMachine.behaviour.GetFarAway() / 4))
        {
            this.stateMachine.SetState(this.stateMachine.repository.Resolve<StopState>());
        }

        this.stateMachine.behaviour.ChangeDestination(destination);
    }
}
