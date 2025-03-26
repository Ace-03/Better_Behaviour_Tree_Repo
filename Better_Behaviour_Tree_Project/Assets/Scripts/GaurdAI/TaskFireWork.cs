using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskFireWork : Node
{
    private GameObject _knight;
    private GuardBT _guardBT;

    public override NodeState Evaluate()
    {
        _knight = GameObject.Find("ToonRTS_demo_Knight");

        _guardBT = _knight.GetComponent<GuardBT>();

        Debug.Log("Firework");
        Debug.Log(_guardBT.fireWork);
        //if (true)

        if (!_guardBT.fireWork.isPlaying)
        {
            _guardBT.fireWork.Play();
            state = NodeState.RUNNING;
            return state;

        }



        //_guardBT.fireWork.Stop();
        state = NodeState.FAILURE;
        return state;
    }
}
