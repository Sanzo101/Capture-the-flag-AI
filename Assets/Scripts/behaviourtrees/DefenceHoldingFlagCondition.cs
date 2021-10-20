using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DefenceHoldingFlagCondition : Node
{
    AI ai;

    public DefenceHoldingFlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {

        if (HasFlag(ai))
        {

            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;

    }

    public static bool HasFlag(AI ai)
    {

        if (ai.GetAgentInventory().HasItem(ai.GetAgentData().EnemyFlagName))
        {
            
            return true;
        }
          else   return false;

    }
}