using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpTeamFlag : Node
{
    AI ai;
     public PickUpTeamFlag(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        //Get flag
        var flag = GameObject.Find(ai.GetAgentData().FriendlyFlagName);
        if (ai.GetAgentSenses().IsItemInReach(flag))
        {
            //If I am close enough, pick it up
            ai.GetAgentActions().CollectItem(flag);
        }
        else
        {
            //If we can't see, just move to its location
            ai.GetAgentActions().MoveTo(flag);
        }

        return NodeState.RUNNING;
    }
}

