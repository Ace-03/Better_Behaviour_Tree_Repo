using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

public class TaskAttackBox : Node
{
    private Transform _lastTarget;
    private EnemyManager _enemyManager;
    private GuardBT _guardBT;
    private GameObject _crate;

    private float _attackTime = 1f;
    private float _attackCounter = 0f;



    public override NodeState Evaluate()
    {
        
        Transform target = (Transform)GetData("target");

        _guardBT = GameObject.Find("ToonRTS_demo_Knight").GetComponent<GuardBT>();

        

        if (target != _lastTarget)
        {
            _enemyManager = target.GetComponent<EnemyManager>();
            _lastTarget = target;
        }

        //if (_enemyManager != null)
        {
            if (_enemyManager._isCrate)
            {
                _attackCounter += Time.deltaTime;
                if (_attackCounter >= _attackTime)
                {
                    bool enemyIsDead = _enemyManager.TakeHit();
                    if (enemyIsDead)
                    {
                        ClearData("target");
                        //_animator.SetBool("Attacking", false);
                        //_animator.SetBool("Walking", true);

                        _guardBT.firePart.Stop();
                    }
                    else
                    {
                        _guardBT.firePart.Play();
                        _attackCounter = 0f;
                    }
                }
            }
            else
            {
                Debug.Log("!");
                state = NodeState.FAILURE;
                return state;
            }
        }
        

        //state = NodeState.SUCCESS;
        return state;
        

        
    }
}
