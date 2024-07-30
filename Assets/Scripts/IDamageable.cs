using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{ 
    float _maxHealth { get; set; }
    float _currentHealth { get; set; }
    public void ApplyDamage(float dmg);
    
   
}
