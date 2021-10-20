using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class HasFlagCondition : Node
{
    AI ai;
    public HasFlagCondition(AI ai)
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
        return ai.GetAgentData().HasEnemyFlag;
    }
}

