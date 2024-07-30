using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]
    private Transform _billTarget;
    void Update()
    {
        transform.LookAt(_billTarget);
    }
}
