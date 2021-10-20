using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class FollowTeamMateWithEnemyFlag : Node
{
    AI ai;
    public FollowTeamMateWithEnemyFlag(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        //Get enemy flag
        GameObject enemyFlag = GameObject.Find(ai.GetAgentData().EnemyFlagName);
        if (!enemyFlag) 
            return 0 ;
         
        //Get owner of flag
        var teamMate = enemyFlag.transform.parent.position;
        //Apply slight radius to teammate's location
        var finalPos = (UnityEngine.Random.insideUnitSphere * 5) + teamMate;

        //Move to teammate 
        ai.GetAgentActions().MoveTo(finalPos);
        return NodeState.RUNNING;
    }

    
}

