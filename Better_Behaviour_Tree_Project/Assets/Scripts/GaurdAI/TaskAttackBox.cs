using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

public class TaskAttackBox : Node
{
    private Transform _lastTarget;
    private EnemyManager _enemyManager;
    public GuardBT _guardBT;

    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    void Start()
    {
        //_guardBT = FindObjectsOfType<GuardBT>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _enemyManager = target.GetComponent<EnemyManager>();
            _lastTarget = target;
        }

        _attackCounter += Time.deltaTime;
        if (_attackCounter >= _attackTime)
        {
            bool enemyIsDead = _enemyManager.TakeHit();
            if (enemyIsDead)
            {
                ClearData("target");
                //_animator.SetBool("Attacking", false);
                //_animator.SetBool("Walking", true);
            }
            else
            {
                _guardBT.firePart.Play();
                _attackCounter = 0f;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
