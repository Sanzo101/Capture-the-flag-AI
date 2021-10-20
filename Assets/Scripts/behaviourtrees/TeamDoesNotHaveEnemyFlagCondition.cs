using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class TeamDoesNotHaveEnemyFlagCondition : Node
{
    AI ai;

    public TeamDoesNotHaveEnemyFlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (TeamDoesNotHaveEnemyFlag(ai))
        {
            
            return NodeState.SUCCESS;
        }
        else
            
            return NodeState.FAILURE;
    }

    public static bool TeamDoesNotHaveEnemyFlag(AI ai)
    {
        //Get enemy's flag
        GameObject flag = GameObject.Find(ai.GetAgentData().EnemyFlagName);
        if (!flag) return false;

        //If its parent is null, no one has it
        if (!flag.transform.parent)
        {
            
            return true;
        }
        else
            
            return false;

        
      
    }
}