using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class SeenEnemyCondition : Node
{
    AI ai;

    public SeenEnemyCondition(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (SeenEnemy(ai))
        {
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }

    public static bool SeenEnemy(AI ai)
    {
        //Get all enemies
        var enemies = ai.GetAgentSenses().GetEnemiesInView();
        if (enemies.Count == 0)
            return false;

        //Set my target as the first enemy
        ai.SetTarget(enemies[0].GetComponent<AI>());

        return true;
    }
}

