using UnityEngine;
using System.Collections;

public class AIRobotBehaviour : AIBehaviour 
{
    private AIRobotStateMachine stateMachine;

    public Shooter shooter;
    public Timer waitToShoot;
    public Timer timeBetweenShots;

    private void Start()
    {
        this.stateMachine = new AIRobotStateMachine(this);
        this.stateMachine.SetState(this.stateMachine.repository.Resolve<AggressiveState>());
    }

    private void Update()
    {
        if(this.stateMachine != null)
        {
            this.stateMachine.UpdateState();
        }
    }

    protected override void OnHurt()
    {
        this.animator.Play(Animation.Hit);
    }
}