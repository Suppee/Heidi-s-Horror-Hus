using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    //Flashlight variables
    [SerializeField] GameObject FlashlightLight;
    bool FlashlightActive = false;
    [SerializeField] private AudioClip FlashlightClick;
    [SerializeField] private AudioSource audioSource;


    // Input value from flashlight
    public void Lighting(InputAction.CallbackContext context)
    {

        if (context.performed && FlashlightActive)
        {
            FlashlightActive = false;
        }
        else if (context.performed)
        {
            FlashlightActive = true;
        }

        if (FlashlightActive)
        {
            FlashlightLight.gameObject.SetActive(true);
            if (GetComponent<AudioSource>().isPlaying == false)
            {
                audioSource.clip = FlashlightClick;
                audioSource.Play();
            }
        }
        else
        {
            FlashlightLight.gameObject.SetActive(false);
            if (GetComponent<AudioSource>().isPlaying == false)
            {
                audioSource.clip = FlashlightClick;
                audioSource.Play();
            }
        }
    }
}
