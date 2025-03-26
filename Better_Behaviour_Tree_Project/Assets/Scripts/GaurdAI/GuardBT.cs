using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class GuardBT : BehaviorTree.Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    public ParticleSystem firePart;
    public ParticleSystem fireWork;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttackBox(),

            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new Sequence(new List<Node>
            {
                new TaskJump(),
            }),
            new Sequence(new List<Node>
            {
                new TaskFireWork(),
            }),
            new TaskPatrol(transform, waypoints),
        }) ;

        return root;
    }
}
