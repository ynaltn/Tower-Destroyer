using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : AnimatorManager
{

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
    }


}
