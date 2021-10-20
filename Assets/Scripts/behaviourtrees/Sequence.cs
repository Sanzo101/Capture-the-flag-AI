using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;
        foreach(var node in nodes)
        {
            switch(node.Evaluate())
            {     
                case NodeState.SUCCESS:
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    continue;
                default:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                    
            }
        }
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _nodeState;
    }
}
