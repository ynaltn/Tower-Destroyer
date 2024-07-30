using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerControlManager : WeaponControllerMain
{
    [SerializeField] private LazerGun _lazerGun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fireee();
    }

    public void Fireee()
    {
        FireInput();
        if (fire)
        {
            _lazerGun.Fire();
        }
    }
}
