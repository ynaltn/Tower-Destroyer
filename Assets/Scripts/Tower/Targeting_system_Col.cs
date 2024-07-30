using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Targeting_system_Col : MonoBehaviour
{
    public TowerMain _towerMain;
  
    private bool canShoot;
    public GameObject bullet;
    public float cooldownDuration=2f;

    public GameObject[] enemies;
    public Transform[] enemiesSpawnPoints;

    public float shootingDistance;
    private GameObject targetPlayer;
    private float distanceToPlayer;

    private void Start()
    {
        canShoot = true;
    }

    public void AttackPlayer()
    {
        if (canShoot)
        {
            _towerMain.SetTarget(targetPlayer);
            transform.LookAt(targetPlayer.transform.position);
            Rigidbody rb = Instantiate(bullet, transform.position, quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            StartCoroutine(Cooldown());
        }

        
        
    }

    private void Update()
    {
        FindPlayer();
        if (targetPlayer != null)
        {
            
            if (CalculateDistance() <= shootingDistance)
            {
                
                AttackPlayer();
                
            }
        }
        
     
    }



    public void FindPlayer()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public float CalculateDistance()
    {
        return distanceToPlayer = Vector3.Distance(targetPlayer.transform.position, gameObject.transform.position);
    }
    
    private IEnumerator Cooldown()
    {
           canShoot = false;
            yield return new WaitForSeconds(cooldownDuration);
        canShoot = true;
        }
  
}
