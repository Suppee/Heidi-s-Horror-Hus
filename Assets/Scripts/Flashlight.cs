using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    [SerializeField] AudioSource audioSource;
    bool turnOn = false;

    public void TurnOnOff()
    {
        turnOn = turnOn ? false : true;

        if (turnOn)
        {
            FlashlightLight.SetActive(true);
            audioSource.Stop();
            audioSource.Play();
        }
        else
        {
            FlashlightLight.SetActive(false);

            audioSource.Stop();
            audioSource.Play();
        }
    }
}
