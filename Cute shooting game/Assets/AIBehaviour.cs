using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIBehaviour : MovementBase
{
    [Header("Timers")]
    public Timer pushTimer;
    public Timer changeDestinationTimer;
    public Timer stopTimer;

    [Header("AI")]
    public NavMeshAgent navMeshAgent;
    public HealthManager healthManager;
	public float radius;

    [HideInInspector] public Transform target;

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
		if (this.ReachedDestination())
		{
			if (this.stopped == false)
			{
				if(Random.Range(1,3) == 1)
				{
					this.stopTimer.Initilize(() => 
					{
						this.stopped = false;	
					});		
				} 
				else 
				{
					this.changeDestinationTimer.Initilize(ChangeDestination);
				}

				this.stopped = true;
			}
		}

		this.stateMachine.UpdateState();
	}

	public override void Push(Vector3 direction, PushPower force, float? distance = null)
	{
		this.navMeshAgent.enabled = false;
		base.Push(direction, force, distance);

        if (this.healthManager.IsHurt())
        {
            this.target = this.healthManager.source.transform;
            Debug.Log("Is Hurt " + this.target.name);
        }

        this.pushTimer.Initilize(() =>
		{
            Debug.Log("Finished pushing");
			this.navMeshAgent.enabled = true;

            if (!stopped)
			{
				this.navMeshAgent.SetDestination(this.destination);
			}

            this.stateMachine.SetState(this.stateMachine.AggressiveState);
		});
	}

	public void ChangeDestination()
	{
		this.stopped = false;
		this.destination = new Vector3(this.transform.position.x + radius * MathHelper.Choose(-1, 1), this.transform.position.y, this.transform.position.z + radius * MathHelper.Choose(-1, 1));
		this.navMeshAgent.SetDestination(destination);
	}

    public void Chase(Transform target)
    {
        this.target = target;
    }

	private bool ReachedDestination()
	{
		return (Vector3.Distance(this.transform.position, this.navMeshAgent.destination) <= 0.5f);
	}
}

public class AIStateMachine : StateMachine<UnityAction>
{
	private AIBehaviour behaviour;

	public AIStateMachine(AIBehaviour behaviour)
	{
		this.behaviour = behaviour;
	}

	public void StopState()
	{

	}

	public void RoamingState()
	{

	}

	public void AggressiveState()
	{
		if (this.behaviour.navMeshAgent.updateRotation)
		{
			this.behaviour.navMeshAgent.updateRotation = false;
		}

        if(this.behaviour.target != null)
        {
            this.behaviour.LookAt(this.behaviour.target);
        }
	}

    protected override void OnSetState(UnityAction state)
    {
        if(state == this.RoamingState)
        {
            this.behaviour.changeDestinationTimer.Initilize(this.behaviour.ChangeDestination);
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
}