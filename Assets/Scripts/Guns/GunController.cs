using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : WeaponControllerMain
{
     [SerializeField] private Gun gun;
    private void Update()
    {
        Fireee();
    }

    private void Fireee()
    {
        FireInput();
        if (fire)
        {
            gun.Fire();
            if (gun.UseTap())
            {
                fire = false;
            }
        }
    }
}
