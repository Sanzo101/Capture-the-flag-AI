using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class HasFriendlyFlagCondition : Node
{
    AI ai;
    public HasFriendlyFlagCondition(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        if (HasFlag(ai))
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }

    public static bool HasFlag(AI ai)
    {

        if(ai.GetAgentData().HasFriendlyFlag)
        {
           
            return true;
        }
        return false;
    }
}
