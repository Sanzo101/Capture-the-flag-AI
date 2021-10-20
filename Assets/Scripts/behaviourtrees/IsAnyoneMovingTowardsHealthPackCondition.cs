using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class IsAnyoneMovingTowardsHealthPackCondition : Node
{
    AI ai;

    public IsAnyoneMovingTowardsHealthPackCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {

        if (AnyoneMovingToHealthPack(ai))
        {
            return NodeState.FAILURE;
        }

        return NodeState.SUCCESS;
    }


    public static bool AnyoneMovingToHealthPack(AI ai)
    {

        GameObject HealthPack = GameObject.Find("Health Kit");
        GameObject[] friendlyteam = GameObject.FindGameObjectsWithTag(ai.GetAgentData().FriendlyTeamTag);
        GameObject[] enemyteam = GameObject.FindGameObjectsWithTag(ai.GetAgentData().EnemyTeamTag);
     
        for(int i=0; i < enemyteam.Length; i++)
        {
            if(enemyteam[i].GetComponent<AI>().GetAgentActions().MoveTo(HealthPack))
            {
                
                return true;
            }
        }

        for (int i = 0; i < friendlyteam.Length; i++)
        {
            if (friendlyteam[i].GetComponent<AI>().GetAgentActions().MoveTo(HealthPack))
            {
                
                return true;
            }
        }

        

        
        return false;
    }
}

