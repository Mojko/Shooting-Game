using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIBehaviour : MovementBase
{
    public Timer pushTimer;
    public Timer changeDestinationTimer;
    public Timer stopTimer;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator animator;

    public HealthManager healthManager;

    public Transform target;

    private Vector3 destination;
	protected bool stopped;

    private void Awake()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.animator = this.GetComponent<Animator>();
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
        Debug.Log("Changed destination " + destination);
		this.stopped = false;
        this.destination = destination;
		this.navMeshAgent.SetDestination(destination);
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

    public bool IsTargetTooFarAway()
    {
        return Vector3.Distance(this.transform.position, this.target.position) > 15f;
    }

    public bool IsTargetTooClose()
    {
        return Vector3.Distance(this.transform.position, this.target.position) < 10f;
    }

    public void Move()
    {
        if (this.animator.GetFloat("zSpeed") != 1f)
        {
            this.animator.SetFloat("zSpeed", 1f);
        }
    }

    public void Stop()
    {
        if (this.animator.GetFloat("zSpeed") != 0f)
        {
            this.animator.SetFloat("zSpeed", 0f);
        }
    }
}