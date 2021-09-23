using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public UserController userController;
    public AudioSource audio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        float sum = 1;
        Debug.Log(gameObject.tag);
        switch (gameObject.tag)
        {
            case "5":
                sum = 5;
                break;
            case "25":
                sum = 25;
                break;
            case "100":
                sum = 100;
                break;
            case "500":
                sum = 500;
                break;
        }

        userController.coins += sum;
        audio.Play();
        Destroy(gameObject);
    }
}