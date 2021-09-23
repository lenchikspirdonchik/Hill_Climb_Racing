using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backTire, frontTire, carController;
    public float speed = 80f, carTorque = 10f;
    public float fuel = 1;
    public float fuelСonsumption = 0.1f;
    private float _movement = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        _movement = Input.GetAxis("Horizontal") * -1;
        carTorque = _movement * 10f;
    }

    private void FixedUpdate()
    {
        if (fuel > 0)
        {
            backTire.AddTorque(_movement * speed * Time.fixedDeltaTime);
            frontTire.AddTorque(_movement * speed * Time.fixedDeltaTime);
            carController.AddTorque(_movement * carTorque * Time.fixedDeltaTime);
        }

        fuel -= fuelСonsumption * Math.Abs(_movement) * Time.fixedDeltaTime;
    }
}
