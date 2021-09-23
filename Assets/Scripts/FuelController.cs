using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
   public UserController userController;

   private void OnTriggerEnter2D(Collider2D other)
   {
       userController.fuel = 1f;
       Destroy(gameObject);
   }
}
