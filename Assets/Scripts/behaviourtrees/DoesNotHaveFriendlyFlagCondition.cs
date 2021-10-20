using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DoesNotHaveFriendlyFlagCondition : Node
{
    AI ai;
    public DoesNotHaveFriendlyFlagCondition(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        if (HasFlag(ai))
            return NodeState.FAILURE;
        else
            return NodeState.SUCCESS;
    }

    public static bool HasFlag(AI ai)
    {
        return ai.GetAgentData().HasFriendlyFlag;
    }
}
