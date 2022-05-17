using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_DoubleDoor : MonoBehaviour
{
    [SerializeField] DoubleDoor doubleDoor;
    [HideInInspector] public bool tjek = true;

    void OnTriggerEnter(Collider other)
    {
        if(tjek == true)
        {
            doubleDoor.Interact();
            tjek = false;
        }
    }
}