using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPConroller : MonoBehaviour, IDamageable
{
    public float _maxHealth { get; set ; }
    public float _currentHealth { get ; set ; }

    private void Start()
    {
        _maxHealth = 10000;
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float dmg)
    {
        _currentHealth -= dmg;
        die();
    }

    public void die()
    {
        if (_currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

}
