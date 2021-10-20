using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class HealthPackAvailableCheck : Node
{

    AI ai;
    

    public HealthPackAvailableCheck(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
       if(IsHealthPackAvailable())
        {
            
            return NodeState.SUCCESS;
        }
       else
        {
            return NodeState.FAILURE;
        }

    }
    public bool IsHealthPackAvailable()
    {
        
        GameObject healthpack = GameObject.Find("Health Kit");
        return healthpack;
    }
    
    
}



