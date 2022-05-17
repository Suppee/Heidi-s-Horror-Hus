using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Door : MonoBehaviour
{
    [SerializeField] Door door;
    [HideInInspector] public bool tjek = true;

    void OnTriggerEnter(Collider other)
    {
        if (tjek == true)
        {
            door.Interact();
            tjek = false;
        }
    }
}
