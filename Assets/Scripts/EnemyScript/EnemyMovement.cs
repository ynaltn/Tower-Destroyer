using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    Enemy enemy;
    public NavMeshAgent navMeshAgent;
    EnemyStats enemyStats;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        enemyStats = GetComponent<EnemyStats>();
    }

    void Update()
    {
       
    }

    public void ChasePlayer(GameObject target)
    {
        navMeshAgent.speed = enemyStats.enemySpeed;
        navMeshAgent.SetDestination(target.transform.position);
    }

    

    
}
