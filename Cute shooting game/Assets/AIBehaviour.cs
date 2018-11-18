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

    [Header("Notify me")]
    public AIController aiController;

    public Transform target;

    private Vector3 destination;
	protected bool stopped;

	public override void Push(Vector3 direction, PushPower force, float? distance = null)
	{
		this.navMeshAgent.enabled = false;
		base.Push(direction, force, distance);

        if (this.healthManager.IsHurt())
        {
            this.target = this.healthManager.source.transform;
            Debug.Log("Is Hurt " + this.target.name);
        }

        this.pushTimer.StartTimer(() =>
		{
            Debug.Log("Finished pushing");
			this.navMeshAgent.enabled = true;

            if (!stopped)
			{
				this.navMeshAgent.SetDestination(this.destination);
			}
		});
	}

	public void ChangeDestination(Vector3 destination)
	{
        Debug.Log("Changed destination");
		this.stopped = false;
        this.destination = destination;
		this.navMeshAgent.SetDestination(destination);
        this.aiController.OnChangeDestination();
	}

    public void Chase(Transform target)
    {
        this.target = target;
    }

	private bool HasReachedDestination()
	{
		return Vector3.Distance(this.transform.position, this.navMeshAgent.destination) <= 0.5f;
	}

    public bool IsMoving()
    {
        return !this.stopped;
    }

    public bool CanMoveTowards()
    {
        return Vector3.Distance(this.transform.position, this.target.position) > 15f;
    }
}