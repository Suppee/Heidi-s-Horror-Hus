using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    [SerializeField] AudioSource audioSource;
    public bool turnOn = false;
    public bool recharged = true;
    public float batteryCharge;
    public float charging;
    public float maxCharge;
    public float time;

    public void FixedUpdate()
    {
        if (turnOn)
        {
            batteryCharge -= Time.fixedDeltaTime;
        }
        else if (batteryCharge < maxCharge)
        {
            batteryCharge += Time.fixedDeltaTime * charging;
        }

        if (batteryCharge <= 0)
        {
            turnOn = false;
            FlashlightLight.SetActive(false);
            recharged = false;
            StartCoroutine(Recharge());
        }
    }

    public void TurnOnOff()
    {
        turnOn = turnOn ? false : true;

        if (turnOn && recharged)
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

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(time);
        turnOn = false;
        recharged = true;
    }
}
