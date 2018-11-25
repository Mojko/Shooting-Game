using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIBehaviour : MovementBase
{
    public Timer pushTimer;
    public Timer changeDestinationTimer;
    public Timer stopTimer;
    public HealthManager healthManager;
    public Transform target;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator animator;

    private Vector3 destination;
    public HurtEffect hurtEffect;
	protected bool stopped;

    private void Awake()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.animator = this.GetComponent<Animator>();
        this.hurtEffect = this.GetComponent<HurtEffect>();
    }

    public override void Push(Vector3 direction, PushPower force, float? distance = null)
	{
		this.navMeshAgent.enabled = false;
        //base.Push(direction, force, distance);

        this.hurtEffect.Enable();

        if (this.healthManager.IsHurt())
        {
            this.target = this.healthManager.source.transform;
            this.OnHurt();
        }

        this.pushTimer.StartTimer(() =>
		{
			this.navMeshAgent.enabled = true;

            if (!stopped)
			{
				this.navMeshAgent.SetDestination(this.destination);
			}
		});
	}

	public void ChangeDestination(Vector3 destination)
	{
        destination = new Vector3(destination.x, this.transform.position.y, destination.z);
		this.stopped = false;
        this.destination = destination;

        if (!this.IsMovingAnimated())
        {
            this.Move();
        }
        
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

    public bool IsMovingAnimated()
    {
        return this.animator.GetFloat("zSpeed") != 0;
    }

    public bool IsTargetTooFarAway()
    {
        return Vector3.Distance(this.transform.position, this.target.position) > GetFarAway();
    }

    public float GetClose()
    {
        return 10f;
    }

    public float GetFarAway()
    {
        return 35f;
    }

    public bool IsTargetTooFarAwayCalculation(float custom)
    {
        return Vector3.Distance(this.transform.position, this.target.position) > custom;
    }

    public bool IsTargetTooClose()
    {
        return Vector3.Distance(this.transform.position, this.target.position) < GetClose();
    }

    public bool IsTargetVisible()
    {
        return RayCastHelper.ShootLine(this.transform.position, this.target.position);
    }

    public void Move()
    {
        this.animator.SetFloat("zSpeed", 1f);
    }

    public void Stop()
    {
        this.animator.SetFloat("zSpeed", 0f);
    }

    public bool AvoidWalls()
    {
        bool backward = RayCastHelper.ShootRay(this.transform.position, -this.transform.forward, 1f);
        bool left = RayCastHelper.ShootRay(this.transform.position, -this.transform.right, 1f);
        bool right = RayCastHelper.ShootRay(this.transform.position, this.transform.right, 1f);

        Vector3 destination = Vector3.zero;

        if (backward || right)
        {
            destination = this.transform.position - (this.transform.right * 1.5f);
            this.ChangeDestination(destination);
            return true;
        }
        else if (left)
        {
            destination = this.transform.position + this.transform.right * 1.5f;
            this.ChangeDestination(destination);
            return true;
        }

        return false;
    }

    protected virtual void OnHurt()
    {

    }
}