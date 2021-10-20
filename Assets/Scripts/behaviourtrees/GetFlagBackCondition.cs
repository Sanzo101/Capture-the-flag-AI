using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GetFlagBackCondition : Node
{

    AI ai;

    public GetFlagBackCondition(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        if (IsFlagOutsideBase(ai))
        {
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }

    public static bool IsFlagOutsideBase(AI ai)
    {
        //Get the flag
        var flag = GameObject.Find(ai.GetAgentData().FriendlyFlagName).GetComponent<BoxCollider>();
        if (!flag) return false;

        
        var halfBounds = ai.GetAgentData().FriendlyBase.GetComponent<BoxCollider>().bounds;
        halfBounds.size /= 2;

        //Is the bounds not within the bounds of the base
        return !halfBounds.Intersects(flag.bounds);
    }
}

