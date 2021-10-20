using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class isPowerUpWithingDecentRange : Node
{

    AI ai;

    public isPowerUpWithingDecentRange(AI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (PowerUpAvailable(ai))
        {

            return NodeState.SUCCESS;
        }
        else
           
        return NodeState.FAILURE;
    }
    public static bool PowerUpAvailable(AI ai)
    {
        GameObject powerUp = GameObject.Find("Power Up");
   
        return powerUp;
    }
}

