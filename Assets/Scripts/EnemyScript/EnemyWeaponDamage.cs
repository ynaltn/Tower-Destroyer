using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    EnemyStats stats;
    private void Start()
    {
        stats = GetComponentInParent<EnemyStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHPConroller>().ApplyDamage(stats.enemyDamage);
        }
    }
}
