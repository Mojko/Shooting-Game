using System;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : Movement
{
    public NavMeshAgent navMeshAgent;
    public Transform target;
    public float radius;
    public Timer pushTimer;
    public Timer changeDestinationTimer;
    public Timer stopTimer;

    private Vector3 destination;
    private bool stopped;
    private AIStateMachine stateMachine;

    private void Start()
    {
        this.stateMachine = new AIStateMachine(this);
        this.stateMachine.SetState(this.stateMachine.RoamingState);
        this.ChangeDestination();
    }

    private void Update()
    {
        if(this.ReachedDestination())
        {
            if(this.stopped == false)
            {
                this.changeDestinationTimer.Initilize(ChangeDestination);
                this.stopped = true;
            }
        }
    }

    public override void Push(Vector3 direction, PushPower force, float? distance = null)
    {
        this.navMeshAgent.enabled = false;
        base.Push(direction, force, distance);
        this.pushTimer.Initilize(PushTimerOnEnd);
    }

    private void PushTimerOnEnd()
    {
        this.navMeshAgent.enabled = true;
        if (!stopped)
        {
            //this.navMeshAgent.SetDestination(this.destination);
        }

        this.stateMachine.SetState(this.stateMachine.AggressiveState);
    }

    private void ChangeDestination()
    {
        this.stopped = false;
        this.destination = new Vector3(target.position.x - radius * MathHelper.Choose(-1, 1), target.position.y, target.position.z - radius * MathHelper.Choose(-1, 1));
        this.navMeshAgent.SetDestination(destination);
    }

    private bool ReachedDestination()
    {
        return (Vector3.Distance(this.transform.position, this.navMeshAgent.destination) <= 0.5f);
    }
}

public class AIStateMachine : StateMachine<Action>
{
    private AIMovement movement;

    public AIStateMachine(AIMovement movement)
    {
        this.movement = movement;
    }

    public void StopState()
    {

    }

    public void RoamingState()
    {

    }

    public void AggressiveState()
    {

    }

    protected override void OnSetState()
    {
        Action action = this.GetState();
        if(action != null)
        {
            action.Invoke();
        }
    }
}