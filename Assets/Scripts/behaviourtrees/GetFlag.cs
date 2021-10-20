using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GetFlag : Node
{
    private AI ai;


    public GetFlag(AI ai)
    {
        this.ai = ai;

    }

    public override NodeState Evaluate()
    {


        


        GameObject enemyflag = GameObject.Find(ai.GetAgentData().EnemyFlagName);
       
            //If flag was in view, move to it
            ai.GetAgentActions().MoveTo(enemyflag);
            
        

        return NodeState.RUNNING;
        
      

    }
}
