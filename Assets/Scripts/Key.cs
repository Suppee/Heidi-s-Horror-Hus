using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField] private AudioClip ItemCollected;
    [SerializeField] private AudioSource audioSource;
    public string keycode;
    public override void Interact()
    {
        playerController.keyring.Add(this);
        gameObject.SetActive(false);
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            audioSource.clip = ItemCollected;
            audioSource.Play();
        }
    }

}
