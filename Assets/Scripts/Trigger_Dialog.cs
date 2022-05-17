using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dialog : MonoBehaviour
{
    [SerializeField] AudioSource player;
    [SerializeField] AudioClip dialog;
    [HideInInspector] public bool tjek = true;

    void OnTriggerEnter(Collider other)
    {
        if (tjek == true)
        {
            player.clip = dialog;
            player.Play();
            tjek = false;
        }
    }
}
