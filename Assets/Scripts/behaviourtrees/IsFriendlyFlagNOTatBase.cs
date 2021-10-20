using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class IsFriendlyFlagNOTatBase : Node
{

    AI ai;

    public IsFriendlyFlagNOTatBase(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        if (TeamFlagIsAtBase(ai))
        {
            
            return NodeState.SUCCESS;
        }
        else
            
        return NodeState.FAILURE;
    }

    public static bool TeamFlagIsAtBase(AI ai)
    {
        //Get the flag
        GameObject TeamFlag = GameObject.Find(ai.GetAgentData().FriendlyFlagName);
        GameObject TeamBase = ai.GetAgentData().FriendlyBase;

        BoxCollider flagCollider = TeamFlag.GetComponent<BoxCollider>();
        BoxCollider BaseCollider = TeamBase.GetComponent<BoxCollider>();


        //Is the bounds  within the bounds of the base
        if (flagCollider.bounds.Intersects(BaseCollider.bounds))
        {
            
            return true;
        }
        else
            return false;
    }
}

