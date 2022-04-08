using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Interactable
{
    [SerializeField] private AudioClip ItemCollected;
    [SerializeField] private AudioSource audioSource;

    public override void Interact()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            audioSource.clip = ItemCollected;
            audioSource.Play();
        }
        gameObject.SetActive(false);
    }
}
