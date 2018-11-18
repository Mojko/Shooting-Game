using UnityEngine;
using System.Collections;

public class AIRobotBehaviour : AIBehaviour 
{
    private AIRobotStateMachine stateMachine;

    public Shooter shooter;

    private void Start()
    {
        this.stateMachine = new AIRobotStateMachine(this);
        this.stateMachine.SetState(this.stateMachine.AggressiveState);
    }

    private void Update()
    {
        this.stateMachine.UpdateState();

        if (this.stateMachine.GetState() == this.stateMachine.AggressiveState)
        {
            this.aiController.Move();
        }
        else
        {
            this.aiController.Stop();
        }
    }
}