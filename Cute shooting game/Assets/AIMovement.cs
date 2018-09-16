using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

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
		this.stateMachine.SetState(this.stateMachine.AggressiveState);
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

		this.pushTimer.Initilize(() =>
		{
			this.navMeshAgent.enabled = true;
			if (!stopped)
			{
				this.navMeshAgent.SetDestination(this.destination);
			}

			this.stateMachine.SetState(this.stateMachine.AggressiveState);
		});
	}

	private void ChangeDestination()
	{
		this.stopped = false;
		this.destination = new Vector3(this.transform.position.x + radius * MathHelper.Choose(-1, 1), this.transform.position.y, this.transform.position.z + radius * MathHelper.Choose(-1, 1));
		this.navMeshAgent.SetDestination(destination);
	}

	private bool ReachedDestination()
	{
		return (Vector3.Distance(this.transform.position, this.navMeshAgent.destination) <= 0.5f);
	}
}

public class AIStateMachine : StateMachine<UnityAction>
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
		if (this.movement.navMeshAgent.updateRotation)
		{
			this.movement.navMeshAgent.updateRotation = false;
		}

		this.movement.Rotate(this.movement.target);
		//this.movement.transform.rotation = Quaternion.LookRotation(new Vector3(this.movement.target.transform.position.x, this.movement.transform.position.y, this.movement.target.transform.position.z));
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