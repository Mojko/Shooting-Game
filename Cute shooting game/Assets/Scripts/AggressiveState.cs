using UnityEngine;
using System.Collections;
using System;

public class AggressiveState : State<AIRobotStateMachine>
{
    public AggressiveState(AIRobotStateMachine subject)
        : base(subject)
    {
    }

    public override void OnSet()
    {
        this.stateMachine.behaviour.animator.SetBool("Shoot", false);
    }

    public override void Update()
    {
        if (this.stateMachine.behaviour.navMeshAgent.updateRotation)
        {
            this.stateMachine.behaviour.navMeshAgent.updateRotation = false;
        }

        if (this.stateMachine.behaviour.target != null)
        {
            this.stateMachine.behaviour.LookAt(this.stateMachine.behaviour.target);
        }

        if (!this.stateMachine.behaviour.IsTargetTooFarAway())
        {
            this.stateMachine.SetState(this.stateMachine.stopState);
        }
        else
        {
            this.stateMachine.behaviour.ChangeDestination(this.stateMachine.behaviour.target.transform.position);
        }
    }
}
