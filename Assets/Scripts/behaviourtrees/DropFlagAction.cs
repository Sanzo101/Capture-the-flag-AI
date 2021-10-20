using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DropFlagAction : Node
{
    AI ai;
     public DropFlagAction(AI ai)
         {
             this.ai = ai;
         }
    public override NodeState Evaluate()
    {
        var flag = GameObject.Find(ai.GetAgentData().FriendlyFlagName);
        
        
            ai.GetAgentActions().DropItem(flag);
            
        
        return NodeState.RUNNING;
    }
}

