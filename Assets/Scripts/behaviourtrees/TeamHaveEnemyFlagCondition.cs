using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class TeamHaveEnemyFlagCondition : Node
{
    AI ai;

    public TeamHaveEnemyFlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (TeamHasTheEnemyFlag(ai))
        {
            return NodeState.SUCCESS;
        }
        else return NodeState.FAILURE;
    }

    public static bool TeamHasTheEnemyFlag(AI ai)
    {
        //Get enemy's flag
        GameObject flag = GameObject.Find(ai.GetAgentData().EnemyFlagName);
        if (!flag) return false;

        //If its parent is null, no one has it
        if (!flag.transform.parent) return false;

        //Check if its parent's tag is that of my team
        return flag.transform.parent.CompareTag(ai.GetAgentData().FriendlyTeamTag);
    }
}


