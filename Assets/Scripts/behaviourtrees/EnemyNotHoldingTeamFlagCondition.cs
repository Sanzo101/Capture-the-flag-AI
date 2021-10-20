using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyNotHoldingTeamFlagCondition : Node
{
    AI ai;

    public EnemyNotHoldingTeamFlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (DoesEnemyNOThaveTeamFlag(ai))
        {
            
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }
    public static bool DoesEnemyNOThaveTeamFlag(AI ai)
    {
        //Get my flag's object
        GameObject flag = GameObject.Find(ai.GetAgentData().FriendlyFlagName);

        //If it doesn't have a parent, no one has the flag
        if (!flag.transform.parent) return true;

        //If the flag's parent's tag is that of the enemy
        if (flag.transform.parent.CompareTag(ai.GetAgentData().EnemyTeamTag))
        {
            
            return false;
        }
        else return true;
        
    }
}