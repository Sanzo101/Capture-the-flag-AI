using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
public class TeamHaveTeamFlagCondition : Node
{
    AI ai;

    public TeamHaveTeamFlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (TeamDoesNotHaveTheTeamFlag(ai))
        {
            
            return NodeState.FAILURE;
        }
        
        else
            
        return NodeState.SUCCESS;
    }

    public static bool TeamDoesNotHaveTheTeamFlag(AI ai)
    {
        //Get our flag
        GameObject flag = GameObject.Find(ai.GetAgentData().FriendlyTeamTag);
        if (!flag) return false;

        //If its parent is null, no one has it
        if (!flag.transform.parent) return false;


        //Check if its parent's tag is that of my team
        if (flag.transform.parent.name.Equals(ai.GetAgentData().FriendlyTeam))
        {
            
            return true;
        }
        else return false;
    }
}
