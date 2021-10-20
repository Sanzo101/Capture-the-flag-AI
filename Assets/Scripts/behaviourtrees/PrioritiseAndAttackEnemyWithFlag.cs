using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PrioritiseAndAttackEnemyWithFlag : Node
{
    AI ai;

    public PrioritiseAndAttackEnemyWithFlag(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        //Get enemy with flag
        AI enemy = GameObject.Find(ai.GetAgentData().FriendlyFlagName).transform.parent.gameObject.GetComponent<AI>();
        //Set him as my target
        ai.SetTarget(enemy);
        Debug.Log("Prioritise Enemy");
        //Attack him
        ai.GetAgentActions().MoveTo(ai.GetTarget().gameObject);
        ai.GetAgentActions().AttackEnemy(ai.GetTarget().gameObject);

        
        return NodeState.RUNNING;
    }
}

