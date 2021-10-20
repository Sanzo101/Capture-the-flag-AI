using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GoToTeamBase : Node
{
    AI ai;

    public GoToTeamBase(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {

        if(AIisAThome(ai))
        {
                     
            return NodeState.SUCCESS;
        }
        

        else
           
            ai.GetAgentActions().MoveTo(ai.GetAgentData().FriendlyBase);
            return NodeState.RUNNING;
    }

    public static bool AIisAThome(AI ai)
    {
        if (ai.GetAgentData().FriendlyBase.GetComponent<BoxCollider>().bounds.Intersects(ai.GetComponent<CapsuleCollider>().bounds))
        {
            return true;
        }
        else return false;
    }
}

