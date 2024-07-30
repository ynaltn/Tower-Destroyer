using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    Enemy enemy;
    EnemyMovement enemyMovement;
    public EnemyChaseState chaseState;
    EnemyAnimatorManager enemyAnimatorManager;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
        enemyAnimatorManager = GetComponentInParent<EnemyAnimatorManager>();
    }

    public override State RunCurrentState()
    {
        //Attack fonksiyonu
        Debug.Log("Saldýrýyor");
        
        enemyAnimatorManager.PlayTargetAnimation("Attack", true);
        if (enemy.distanceToTarget > enemyMovement.navMeshAgent.stoppingDistance)
        {
            DisableAttack();
            return chaseState;
        }
        else
        {
            return this;
        }

    }
     void DisableAttack()
    {
        enemyAnimatorManager.PlayTargetAnimation("Attack", false);
        chaseState.isInAttackRange = false;
    }
}
