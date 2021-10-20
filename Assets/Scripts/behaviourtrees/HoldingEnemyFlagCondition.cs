using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class HoldingEnemyFlagCondition : Node
{

    AI ai;

    public HoldingEnemyFlagCondition(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        if (HoldingEnemyFlag(ai))
        {
            
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }

    public static bool HoldingEnemyFlag(AI ai)
    {
        //Get flag and check if its parent is me
        return GameObject.Find(ai.GetAgentData().EnemyFlagName).transform.parent == ai.transform;
    }
}
