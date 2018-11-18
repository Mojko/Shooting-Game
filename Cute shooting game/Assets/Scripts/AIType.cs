using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public enum AIType 
{
    Robot
}

public class AIHelper
{
    public static StateMachine<UnityAction> GetStateMachine(AIType type, AIBehaviour behaviour)
    {
        switch (type)
        {
            case AIType.Robot:
                return new AIRobotStateMachine((AIRobotBehaviour)behaviour);

            default:
                throw new NotImplementedException("Not implemented this type yet " + type);
        }
    }
}