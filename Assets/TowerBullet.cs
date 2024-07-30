using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject efekt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            var health = col.gameObject.GetComponent<PlayerHPConroller>();
            health.ApplyDamage(20);
            Transform point = col.gameObject.transform;
            Destroy(gameObject);
            Instantiate(efekt, point);
        }
       
    }

   
}
