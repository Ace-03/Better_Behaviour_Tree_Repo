using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskFireWork : Node
{
    public override NodeState Evaluate()
    {


        state = NodeState.FAILURE;
        return state;
    }
}
