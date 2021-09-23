using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
   public CarController carController;

   private void OnTriggerEnter2D(Collider2D other)
   {
       carController.fuel = 1f;
       Destroy(gameObject);
   }
}
