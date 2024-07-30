using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMain : MonoBehaviour
{

    public float fireRate;
    public float damage;
    public bool fireCooldown;

    
    public virtual void Fire()
    {
        
        
    }

    public IEnumerator StopCooldownAfterTime()
    {
        yield return new WaitForSeconds(fireRate);
        fireCooldown = false;
        Debug.Log("çalıştı");
    }
    
   
}
