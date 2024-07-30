using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : MonoBehaviour
{
    private GameObject targetPlayer;
    
    public void SetTarget(GameObject targetPlayer)
    {
        this.targetPlayer = targetPlayer;
        
    }
    
}
