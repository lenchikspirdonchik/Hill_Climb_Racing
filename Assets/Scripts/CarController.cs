using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public Rigidbody2D carController;
    public WheelJoint2D backTire, frontTire;
    public float speed = 100000f, carTorque = 10f;
    public float fuel = 1;
    public float fuelСonsumption = 0.000005f;
    private float _movement = 0f;
    public Image fuelImage;

    void Update()
    {
        // _movement = Input.GetAxis("Horizontal");
        carTorque = _movement * -10f;
        fuelImage.fillAmount = fuel;
    }

    private void FixedUpdate()
    {
        fuel -= fuelСonsumption;
        if (_movement == 0f || fuel == 0f)
        {
            backTire.useMotor = false;
            frontTire.useMotor = false;
        }
        else
        {
            backTire.useMotor = true;
            frontTire.useMotor = true;
            JointMotor2D motor = new JointMotor2D
                { motorSpeed = _movement * speed * Time.deltaTime, maxMotorTorque = 10000 };
            backTire.motor = motor;
            frontTire.motor = motor;
            carController.AddTorque(_movement * carTorque * Time.fixedDeltaTime);
        }
    }

    public void Acclerator(String pedal)
    {
        if (pedal == "Brake")
        {
            _movement = -1;
        }
        else
        {
            if (pedal == "Gas")
            {
                _movement = 1;
            }
            else
            {
                _movement = 0;
            }
        }
    }
}