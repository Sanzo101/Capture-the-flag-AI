using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class FollowTeamMemberWithFlag : Node
{
    AI ai;

    public FollowTeamMemberWithFlag(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        //Get teammate
        var teammate = GameObject.Find(ai.GetAgentData().FriendlyFlagName).transform.parent;
        //Move to him
        ai.GetAgentActions().MoveTo(teammate.gameObject);

        return NodeState.RUNNING;
    }
}

