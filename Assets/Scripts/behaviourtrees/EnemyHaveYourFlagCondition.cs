using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHaveYourFlagCondition : Node
{
    AI ai;

    public EnemyHaveYourFlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (DoesEnemyHaveTeamFlag(ai))
        {
            
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }
    public static bool DoesEnemyHaveTeamFlag(AI ai)
    {
        //Get my flag's object
        GameObject flag = GameObject.Find(ai.GetAgentData().FriendlyFlagName);
        if (!flag) return false;

        //If it doesn't have a parent, no one has the flag
        if (!flag.transform.parent) return false;

        //If the flag's parent's tag is that of the enemy
        return flag.transform.parent.CompareTag(ai.GetAgentData().EnemyTeamTag);
    }
}