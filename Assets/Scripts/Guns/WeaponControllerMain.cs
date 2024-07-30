using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponControllerMain : MonoBehaviour
{
   protected bool fire;
   
   protected void FireInput()
   {
      if (Input.GetMouseButtonDown(0))
      {
         fire= true;
      }

      if (Input.GetMouseButtonUp(0))
      {
         fire = false;
      }
   }
}
