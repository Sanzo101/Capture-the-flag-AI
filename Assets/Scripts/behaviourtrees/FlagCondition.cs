using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FlagCondition : Node
{
    AI ai;

    public FlagCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {

        if (HasFlag(ai))
        {
            
            return NodeState.FAILURE;
        }
        else
            
            return NodeState.SUCCESS;
        

              
        
    }

    public static bool HasFlag(AI ai)
    {
        if(ai.GetAgentInventory().HasItem(ai.GetAgentData().EnemyFlagName))
        {
            
            return true;
        }
        else return false;
       
    
    }
}

