using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckBoxInAttackRange : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckBoxInAttackRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Debug.Log("?");

        Transform target = (Transform)t;
        if (target != null)
        {
            if (Vector3.Distance(_transform.position, target.position) <= GuardBT.attackRange)
            {
                _animator.SetBool("Attacking", true);
                _animator.SetBool("Walking", false);

                state = NodeState.SUCCESS;
                return state;
            }
        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }
        

        state = NodeState.FAILURE;
        return state;
    }
}
