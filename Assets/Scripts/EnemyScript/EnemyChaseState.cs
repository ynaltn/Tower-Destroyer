using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : State
{
    public EnemyAttackState attackState;
    public bool isInAttackRange;
    Enemy enemy;
    EnemyMovement enemyMovement;
    EnemyAnimatorManager enemyAnimatorManager;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        enemyAnimatorManager = GetComponentInParent<EnemyAnimatorManager>();
    }
    public override State RunCurrentState()
    {
        EnemyChaser();

        enemyAnimatorManager.PlayTargetAnimation("Chase", true);

        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
    void EnemyChaser()
    {
        if (enemy.distanceToTarget < enemyMovement.navMeshAgent.stoppingDistance)
        {
            isInAttackRange = true;
        }
        else
        {
            Debug.Log("Takipte");
            enemyMovement.ChasePlayer(enemy.targetPlayer);
        }
    }
}
