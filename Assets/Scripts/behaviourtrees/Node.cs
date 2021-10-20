using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public abstract class Node
{
    /* The current state of the node */
    protected NodeState _nodeState;

    public NodeState nodeState
    {
        get { return _nodeState; }
    }


    /* Implementing classes use this method to evaluate the desired set of conditions */
    public abstract NodeState Evaluate();

}
public enum NodeState
{
    RUNNING, SUCCESS, FAILURE
}