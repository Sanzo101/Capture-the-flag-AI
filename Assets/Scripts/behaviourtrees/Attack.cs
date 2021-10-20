using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Attack : Node
{
    AI ai;
    
    public Attack(AI ai)
    {
        this.ai = ai;
        
    }

    public override NodeState Evaluate()
    {

        ai.GetAgentActions().MoveTo(ai.GetTarget().gameObject);
        //Attack target (function won't allow attacking if we're are too far away so check isn't neccessary
        ai.GetAgentActions().AttackEnemy(ai.GetTarget().gameObject);
        
        return NodeState.RUNNING;

    }
}
