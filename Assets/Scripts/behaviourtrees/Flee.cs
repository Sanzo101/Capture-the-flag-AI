using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class Flee : Node
{
    AI ai;

    public  Flee(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag(ai.GetAgentData().EnemyTeamTag);
        
            ai.GetAgentActions().Flee(enemy);
       
        
        return NodeState.RUNNING;

    }
}

