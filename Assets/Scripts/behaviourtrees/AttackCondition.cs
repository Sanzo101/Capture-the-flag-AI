using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AttackCondition : Node
{

    AI ai;

    public AttackCondition(AI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        
        if (InRange(ai))
        {
            
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
        
    }
    public static bool InRange(AI ai)
    {
        var enemies = ai.GetAgentSenses().GetEnemiesInView();
        if (enemies.Count == 0)
            return false;

        var enemy = enemies.FirstOrDefault(x => ai.GetAgentSenses().IsInAttackRange(x));
        if (enemy == null)
            return false;

        //Set my target as the first enemy
         ai.SetTarget(enemy.GetComponent<AI>());
        return true;
        
    }
}

