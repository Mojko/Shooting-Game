using UnityEngine;
using System.Collections;
using System;

public class StopState : State<AIRobotStateMachine>
{
    public StopState(AIRobotStateMachine subject) 
        : base(subject)
    {
    }

    public override void OnSet()
    {
        this.stateMachine.behaviour.ChangeDestination(this.stateMachine.behaviour.transform.position);
        this.stateMachine.behaviour.animator.SetBool("Shoot", true);
        this.stateMachine.behaviour.animator.SetTrigger("OneHanded");
    }

    public override void Update()
    {
        this.stateMachine.behaviour.shooter.Shoot(this.stateMachine.behaviour.animator);
        this.stateMachine.behaviour.RotateTowards(this.stateMachine.behaviour.target);

        if (this.stateMachine.behaviour.IsTargetTooClose())
        {
            Vector3 destination = Vector3.zero;

            bool backward = RayCastHelper.ShootRay(this.stateMachine.behaviour.transform.position, -this.stateMachine.behaviour.transform.forward, 1f);
            bool left = RayCastHelper.ShootRay(this.stateMachine.behaviour.transform.position, -this.stateMachine.behaviour.transform.right, 1f);
            bool right = RayCastHelper.ShootRay(this.stateMachine.behaviour.transform.position, this.stateMachine.behaviour.transform.right, 1f);

            if (backward || right)
            {
                destination = this.stateMachine.behaviour.transform.position - this.stateMachine.behaviour.transform.right;
            }
            else if (left)
            {
                destination = this.stateMachine.behaviour.transform.position + this.stateMachine.behaviour.transform.right;
            }
            else
            {
                destination = this.stateMachine.behaviour.transform.position - this.stateMachine.behaviour.transform.forward;
            }

            this.stateMachine.behaviour.ChangeDestination(destination);
        }
    }
}
