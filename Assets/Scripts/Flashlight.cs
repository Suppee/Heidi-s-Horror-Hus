using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    bool FlashlightActive = false;

    // Start is called before the first frame update
    void Start()
    {
        FlashlightLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool fPressed = Keyboard.current[Key.F].isPressed;

        if (fPressed && FlashlightActive)
        {
            FlashlightActive = false;
        }
        else if (fPressed)
        {
            FlashlightActive = true;
        }

        if (FlashlightActive)
        {
            FlashlightLight.gameObject.SetActive(true);
        }
        else
        {
            FlashlightLight.gameObject.SetActive(false);
        }
    }
}
