using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IsEnemyflaginsight : Node
{
    private AI ai;


    public IsEnemyflaginsight(AI ai)
    {
        this.ai = ai;

    }

    public override NodeState Evaluate()
    {
        GameObject enemyFlag = GameObject.Find(ai.GetAgentData().EnemyFlagName);
        if (ai.GetAgentSenses().IsItemInReach(enemyFlag))
        {
            
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
       
    }
}
