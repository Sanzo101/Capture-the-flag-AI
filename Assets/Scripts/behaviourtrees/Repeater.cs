using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Repeater : Node
{

    protected Node node;

    public Repeater(Node node)
    {
        this.node = node;
    }

    public override NodeState Evaluate()
    {

        switch (node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                break;
            case NodeState.SUCCESS:
                _nodeState = NodeState.RUNNING;
                break;
            case NodeState.FAILURE:
                _nodeState = NodeState.RUNNING;
                break;
            default:
                _nodeState = NodeState.RUNNING;
                break;
        }

        _nodeState = NodeState.RUNNING;
        return _nodeState;
    }
}

