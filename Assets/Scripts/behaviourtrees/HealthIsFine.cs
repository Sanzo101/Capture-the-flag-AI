using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HealthIsFine : Node
{
    AI ai;

    public HealthIsFine(AI ai)
    {
        this.ai = ai;
       
    }
    public override NodeState Evaluate()
    {
        if (isHealthFine(ai))
        {
            return NodeState.FAILURE;
        }
        
        return NodeState.SUCCESS;
    }
    public static bool isHealthFine(AI ai)
    {
        return ai.GetAgentData().CurrentHitPoints > 5000;
    }
}

