using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    public EnemyChaseState chaseState;
    public bool CanSeeThePlayer;
    Enemy enemy;
    EnemyAnimatorManager enemyAnimatorManager;
    
    float CanSeeFromThisDistance = 15f;

    private void Start()
    {

        enemy = GetComponentInParent<Enemy>();
        enemyAnimatorManager = GetComponentInParent<EnemyAnimatorManager>();
    }
    public override State RunCurrentState()
    {
        TestCanSeePlayer();

        enemyAnimatorManager.PlayTargetAnimation("Idle", true);

        if (CanSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
        
    }
    void TestCanSeePlayer()
    {
        Debug.Log("Oyuncuya olan uzaklýk" + enemy.distanceToTarget);
        Debug.Log(CanSeeFromThisDistance);
        if (enemy.distanceToTarget < CanSeeFromThisDistance)
        {
            Debug.Log("Görüldü");
            CanSeeThePlayer = true;
        }
        else
        {
            CanSeeThePlayer = false;
        }
    }
}
