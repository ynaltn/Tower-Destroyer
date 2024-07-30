using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float _maxHealth { get; set; }
    public float _currentHealth { get; set; }

    public float distanceToTarget;
    public GameObject targetPlayer;
    public void ApplyDamage(float dmg)
    {
        
    }
    private void Awake()
    {
        distanceToTarget = 15;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        CalculateDistanceToPlayer();
        FindTheTargetPlayer();
        
    }
    

    void CalculateDistanceToPlayer()
    {
        
        if (targetPlayer != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, targetPlayer.transform.position);
            distanceToTarget = distanceToPlayer;
        }
        
    }
    void FindTheTargetPlayer()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

}
