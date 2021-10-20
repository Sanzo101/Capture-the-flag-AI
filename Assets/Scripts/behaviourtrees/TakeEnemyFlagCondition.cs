using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class TakeEnemyFlagCondition : Node
{
    AI ai;
    public TakeEnemyFlagCondition(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        if (IsFlagAvailable(ai))
            return NodeState.SUCCESS;
        else
            return NodeState.FAILURE;
    }

    public static bool IsFlagAvailable(AI ai)
    {
        //Get the enemy flag if in view
        GameObject enemyFlag = ai.GetAgentSenses().GetObjectInViewByName(ai.GetAgentData().EnemyFlagName);

        //Return true if the flag is not full and is in reach
        return enemyFlag && ai.GetAgentSenses().IsItemInReach(enemyFlag);
    }
}