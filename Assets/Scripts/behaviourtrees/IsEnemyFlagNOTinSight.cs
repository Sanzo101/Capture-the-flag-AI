using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IsEnemyflagNOTinsight : Node
{
    private AI ai;


    public IsEnemyflagNOTinsight(AI ai)
    {
        this.ai = ai;

    }

    public override NodeState Evaluate()
    {
        GameObject enemyFlag = GameObject.Find(ai.GetAgentData().EnemyFlagName);
        if (ai.GetAgentSenses().IsItemInReach(enemyFlag))
        {
           
            return NodeState.FAILURE;
        }
        else
            
        return NodeState.SUCCESS;

    }
}
