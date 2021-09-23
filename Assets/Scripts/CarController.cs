using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backTire, frontTire, carController;
    public float speed = 80f, carTorque = 10f;
    public float fuel = 5;
    public float fuelСonsumption = 0.1f;
    private float _movement = 0f;
    public Image fuelImage;

    void Update()
    {
        _movement = Input.GetAxis("Horizontal") * -1;
        carTorque = _movement * 10f;
        fuelImage.fillAmount = fuel;
    }

    private void FixedUpdate()
    {
        if (fuel > 0)
        {
            backTire.AddTorque(_movement * speed * Time.deltaTime);
            frontTire.AddTorque(_movement * speed * Time.deltaTime);
            carController.AddTorque(_movement * carTorque * Time.fixedDeltaTime);
        }
        fuel -= fuelСonsumption * Math.Abs(_movement) * Time.fixedDeltaTime;
       
    }
}
