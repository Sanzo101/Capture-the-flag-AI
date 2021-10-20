using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class IsAIAtBaseCondition : Node
{
    AI ai;

    public IsAIAtBaseCondition(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        if (AtTeamBase(ai))
        {
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }

    public static bool AtTeamBase(AI ai)
    {
        //Get my base and check if I am within the bounds of it
        return ai.GetAgentData().FriendlyBase.GetComponent<BoxCollider>().bounds.Intersects(ai.GetComponent<CapsuleCollider>().bounds);
    }
}

