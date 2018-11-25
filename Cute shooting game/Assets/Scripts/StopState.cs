using UnityEngine;
using System.Collections;
using System;

public class StopState : State<AIRobotStateMachine>
{
    public StopState(AIRobotStateMachine subject) 
        : base(subject)
    {
    }

    public override void Start()
    {
        this.stateMachine.behaviour.ChangeDestination(this.stateMachine.behaviour.transform.position);
        this.stateMachine.behaviour.animator.SetBool("Shoot", true);
        this.stateMachine.behaviour.animator.SetTrigger("OneHanded");
        this.stateMachine.behaviour.Stop();
    }

    public override void Update()
    {
        this.stateMachine.behaviour.RotateTowards(this.stateMachine.behaviour.target);

        if (this.stateMachine.behaviour.IsTargetTooClose())
        {
            this.stateMachine.SetState(this.stateMachine.repository.Resolve<EscapeState>());
        }

        if (this.stateMachine.behaviour.IsTargetTooFarAway() || !this.stateMachine.behaviour.IsTargetVisible())
        {
            this.stateMachine.SetState(this.stateMachine.repository.Resolve<AggressiveState>());
        }

        if (!this.stateMachine.behaviour.waitToShoot.IsStarted())
        {
            this.stateMachine.behaviour.waitToShoot.StartTimer(startImmediatly: true);
        }
        else
        {
            if (this.stateMachine.behaviour.animator.IsPlaying(Animation.Shoot_layer_2))
            {
                this.stateMachine.behaviour.shooter.Shoot(this.stateMachine.behaviour.animator);
            }

            if (this.stateMachine.behaviour.shooter.IsOutOfAmmo())
            {
                this.stateMachine.behaviour.shooter.Reload(() =>
                {
                    this.stateMachine.behaviour.animator.SetTrigger("ShootFinalize");

                    return !this.stateMachine.behaviour.animator.IsPlaying(Animation.ShootFinalize);
                });
            }
        }
    }
}
