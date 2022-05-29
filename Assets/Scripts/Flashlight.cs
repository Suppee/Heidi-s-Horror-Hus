using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float chargeMultiplyer;
    [SerializeField] float maxCharge;
    [SerializeField] float rechargeTime;
    [SerializeField] float slowFlickerStart;
    [SerializeField] float fastFlickerStart;

    [HideInInspector] public float batteryCharge;

    bool turnOn = false;
    bool recharged = true;
    bool slowRunning;
    bool fastRunning;

    private void Awake()
    {
        batteryCharge = maxCharge;
        slowRunning = false;
        fastRunning = false;
    }

    public void Update()
    {
        if (turnOn)
        {
            batteryCharge -= Time.deltaTime;
        }
        else if (batteryCharge < maxCharge)
        {
            batteryCharge += Time.deltaTime * chargeMultiplyer;
        }

        if (batteryCharge < slowFlickerStart && batteryCharge > fastFlickerStart && FlashlightLight.activeSelf && !slowRunning)
        {
            slowRunning = true;
            StartCoroutine(SlowFlicker());
        }

        if (batteryCharge < fastFlickerStart && FlashlightLight.activeSelf && !fastRunning)
        {
            slowRunning = false;
            fastRunning = true;

            StopCoroutine(SlowFlicker());
            StartCoroutine(FastFlicker());
        }

        if (batteryCharge <= 0 && FlashlightLight.activeSelf)
        {
            fastRunning = false;
            turnOn = false;
            recharged = false;

            FlashlightLight.SetActive(false);
            StopAllCoroutines();
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

    IEnumerator SlowFlicker()
    {
        while (turnOn)
        {
            FlashlightLight.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));

            if (!turnOn)
            {
                slowRunning = false;
                break;
            }

            FlashlightLight.SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, 4f));
        }

        slowRunning = false;
    }

    IEnumerator FastFlicker()
    {
        while (turnOn)
        {
            FlashlightLight.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));

            if (!turnOn)
            {
                fastRunning = false;
                break;
            }

            FlashlightLight.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.4f, 1.2f));
        }

        fastRunning = false;
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(rechargeTime);
        recharged = true;
    }
}