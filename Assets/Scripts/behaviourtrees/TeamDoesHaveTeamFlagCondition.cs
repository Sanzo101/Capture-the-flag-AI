using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
public class TeamDoesHaveTeamFlagCondition : Node
{
    AI ai;

    public TeamDoesHaveTeamFlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (TeamHasTheteamFlag(ai))
        {
            Debug.Log("WE HAVE OUR FLAG BACK!!");
            return NodeState.SUCCESS;
        }
        else return NodeState.FAILURE;
    }

    public static bool TeamHasTheteamFlag(AI ai)
    {
        //Get enemy's flag
        GameObject flag = GameObject.Find(ai.GetAgentData().FriendlyFlagName);
        if (!flag) return false;

        //If its parent is null, no one has it
        if (!flag.transform.parent) return false;

        //Check if its parent's tag is that of my team
        return flag.transform.parent.CompareTag(ai.GetAgentData().FriendlyTeamTag);
    }
}
