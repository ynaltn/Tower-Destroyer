using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : WeaponMain
{
   [SerializeField] private float fireDistance = 10f;
   [SerializeField] private Transform bulletPoint;
    private RaycastHit hit;
    [SerializeField] private GameObject bullet;
    public override void Fire()
    {
        if (fireCooldown) return;
        Ray ray = new Ray();
        
        
        ray.origin = bulletPoint.position;
        ray.direction = bulletPoint.TransformDirection(Vector3.forward);
        Debug.DrawRay(ray.origin,ray.direction*fireDistance,Color.red);

        GameObject currentbullet = Instantiate(bullet,bulletPoint.position,quaternion.identity);
        float bulletSpeed = 80f;
        currentbullet.GetComponent<Rigidbody>().velocity = bulletPoint.forward * bulletSpeed;
        if (Physics.Raycast(ray, out hit, fireDistance))
        {
            
            

            
            if (hit.collider.CompareTag("Enemy"))
            {
                var health = hit.collider.GetComponent<HealthController>();
                health.ApplyDamage(damage);
                
            }
        }
        StartCoroutine(StopCooldownAfterTime());

        
    }

    public bool UseTap()
    {
        return fireRate == 0;
    }
}
