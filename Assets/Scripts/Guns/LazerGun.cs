using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : WeaponMain
{
    
    [SerializeField] new ParticleSystem particleSystem;

    private List<ParticleCollisionEvent> _collisionEvents;
    
    // Start is called before the first frame update
    void Start()
    {
        _collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject col)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem,col,_collisionEvents);
        for (int i = 0; i < _collisionEvents.Count; i++)
        {
            var collider = _collisionEvents[i].colliderComponent;
            if (collider.CompareTag("Enemy"))
            {
                var health = collider.GetComponent<HealthController>();
                health.ApplyDamage(damage);
            }
        }
    }

    public override void Fire()
    {
        if(fireCooldown)return;
        fireCooldown = true;
        particleSystem.Emit(1);
        StartCoroutine(StopCooldownAfterTime());
    }
    
}
