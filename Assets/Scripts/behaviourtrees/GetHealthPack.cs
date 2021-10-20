using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GetHealthPack : Node
{

    AI ai;

    public GetHealthPack(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        
        GameObject HealthPack = GameObject.Find("Health Kit");

       

            ai.GetAgentActions().MoveTo(HealthPack);
            if (ai.GetAgentSenses().IsItemInReach(HealthPack))
            {
                //If we are close enough to pick it up, collect it and use it
                ai.GetAgentActions().CollectItem(HealthPack);
                ai.GetAgentActions().UseItem(HealthPack);              
                return NodeState.SUCCESS;
            }
        








        return NodeState.RUNNING;

    }
}

