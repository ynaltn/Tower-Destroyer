using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool isPerformingAction;
    EnemyLocomotionManager enemyLocomotionManager;


    [Header("A.I Settings")]
    public float detectionRadius;
    void Start()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();    
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        HandleCurrentAction();
    }
    private void HandleCurrentAction()
    {
        if(enemyLocomotionManager.currentTarget == null)
        {
            enemyLocomotionManager.HandleDetection();
        }
        else if(enemyLocomotionManager.distanceFromTarget > enemyLocomotionManager.stoppingDistance)
        {
            enemyLocomotionManager.HandleMoveToTarget();
        }
        else if(enemyLocomotionManager.distanceFromTarget <= enemyLocomotionManager.stoppingDistance)
        {

        }
    }
    #region Attacks

    #endregion


}
