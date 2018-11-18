using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AIRobotStateMachine : StateMachine<UnityAction>
{
    private readonly AIRobotBehaviour behaviour;

    public AIRobotStateMachine(AIRobotBehaviour behaviour)
    {
        this.behaviour = behaviour;
    }

    public void AggressiveState()
    {
        if (this.behaviour.navMeshAgent.updateRotation)
        {
            this.behaviour.navMeshAgent.updateRotation = false;
        }

        if (this.behaviour.target != null)
        {
            this.behaviour.LookAt(this.behaviour.target);
        }

        if (!this.behaviour.CanMoveTowards())
        {
            this.SetState(this.StopState);
        }
        else
        {
            this.behaviour.ChangeDestination(this.behaviour.target.transform.position);
        }
    }

    public void StopState()
    {
        this.behaviour.shooter.Shoot(this.behaviour.aiController.animator);
        //this.SetState(this.AggressiveState);
    }

    protected override void OnSetState(UnityAction state)
    {
        if (state == this.StopState)
        {
            this.behaviour.ChangeDestination(this.behaviour.transform.position);
            this.behaviour.aiController.animator.SetBool("Shoot", true);
            this.behaviour.aiController.animator.SetTrigger("OneHanded");
        }

        if(state != this.StopState)
        {
            this.behaviour.aiController.animator.SetBool("Shoot", false);
        }
    }

    public override void UpdateState()
    {
        UnityAction action = this.GetState();
        if (action != null)
        {
            action.Invoke();
        }
    }
}           //if (this.stopped == false)
            //{
            //	if(Random.Range(1,3) == 1)
            //	{
            //		this.stopTimer.Initilize(() => 
            //		{
            //			this.stopped = false;	
            //		});		
            //	} 
            //	else 
            //	{
            //		this.changeDestinationTimer.Initilize(ChangeDestination);
            //	}

//	this.stopped = true;
//}