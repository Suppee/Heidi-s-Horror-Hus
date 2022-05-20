using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_Light : MonoBehaviour
{
    [SerializeField] LightControl lightControl;
    [SerializeField] LightControl.LightState newState;
    [HideInInspector] public bool tjek = true;

    void OnTriggerEnter(Collider other)
    {
        if (tjek)
        {
            lightControl.ChangeState(newState.ToString());
            tjek = false;
        }
    }
}
