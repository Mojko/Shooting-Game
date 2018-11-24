using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AIRobotStateMachine : StateMachine<State<AIRobotStateMachine>>
{
    public readonly AIRobotBehaviour behaviour;
    public readonly State<AIRobotStateMachine> aggressiveState;
    public readonly State<AIRobotStateMachine> stopState;

    public AIRobotStateMachine(AIRobotBehaviour behaviour)
    {
        this.behaviour = behaviour;
        this.aggressiveState = new AggressiveState(this);
        this.stopState = new StopState(this);
    }

    protected override void OnSetState(State<AIRobotStateMachine> state)
    {
        state.OnSet();
    }

    public override void UpdateState()
    {
        State<AIRobotStateMachine> state = this.GetState();
        state.Update();
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