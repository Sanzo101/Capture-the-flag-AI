using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MoveToPowerUp : Node
{

    AI ai;

    public MoveToPowerUp(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        GameObject powerUp = GameObject.Find("Power Up");
        ai.GetAgentActions().MoveTo(powerUp);
        if (ai.GetAgentSenses().IsItemInReach(powerUp))
        {
            ai.GetAgentActions().CollectItem(powerUp);
            ai.GetAgentActions().UseItem(powerUp);
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }
    
}
