using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskJump : Node
{
    private GameObject _knight;

    public override NodeState Evaluate()
    {
        _knight = GameObject.Find("ToonRTS_demo_Knight");

        if (_knight.transform.position.y < 2)
        {
            Debug.Log("Jumping");
            _knight.transform.position = new Vector3(_knight.transform.position.x, 2, _knight.transform.position.z);
            state = NodeState.RUNNING;
            return state;
        }

        Debug.Log("Falling");
        _knight.transform.position = new Vector3(_knight.transform.position.x, 0, _knight.transform.position.z);
        state = NodeState.FAILURE;
        return state;
    }
}
