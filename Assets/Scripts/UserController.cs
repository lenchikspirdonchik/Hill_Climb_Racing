using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    [Header("Movement settings")] public Rigidbody2D carController;
    public WheelJoint2D backTire, frontTire;
    public float speed = 100000f, carTorque = 10f;

    [Header("Fuel settings")] public float fuel = 1;
    public float fuelСonsumption = 0.000005f;

    [Header("Coins settings")] public float coins = 0;

    [Header("Canvas settings")] [Tooltip("canvas images")]
    public Image fuelImage, gas, brake, gasPress, breakPress;

    [Tooltip("Canvas texts")] public Text coinCounter;
    private float _movement = 0f;

    private void Start()
    {
        brake.enabled = true;
        breakPress.enabled = false;
        gas.enabled = true;
        gasPress.enabled = false;
    }

    void Update()
    {
        // _movement = Input.GetAxis("Horizontal");
        carTorque = _movement * -10f;
        fuelImage.fillAmount = fuel;
        coinCounter.text = coins.ToString();
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
            brake.enabled = false;
            breakPress.enabled = true;
        }
        else
        {
            if (pedal == "Gas")
            {
                _movement = 1;
                gas.enabled = false;
                gasPress.enabled = true;
            }
            else
            {
                _movement = 0;
                brake.enabled = true;
                breakPress.enabled = false;
                gas.enabled = true;
                gasPress.enabled = false;
            }
        }
    }
}