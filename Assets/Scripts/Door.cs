using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool locked;
    bool open;
    public bool canInteract;
    [SerializeField] private Animator doorAnim;
    [SerializeField] private AudioClip locksound;
    [SerializeField] private AudioClip opensound;
    [SerializeField] private AudioClip closesound;
    [SerializeField] private AudioClip unlocksound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string accesskey;

    public void Awake()
    {
        canInteract = true;
        audioSource = GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        if (!locked)
        {
            if (open && canInteract)
            {
                canInteract = false;
                audioSource.clip = closesound;
                print("close1");
                audioSource.Play();
                print("close2");
                doorAnim.Play("DoorClose", 0, 0.0f);
                print("close3");
                open = false;
                print("close");
            }
            else if (canInteract)
            {
                canInteract = false;
                doorAnim.Play("DoorOpen", 0, 0f);
                print("Open1");
                open = true;
                print("Open2");
                audioSource.clip = opensound;
                print("Open3");
                audioSource.Play();
                print("Open");
            }
        }
        else if (locked && GetComponent<AudioSource>().isPlaying == false)
        {
            for (int i = 0; i < playerController.keyring.Count; i++)
            {
                if (playerController.keyring[i].keycode == accesskey)
                {
                    locked = false;
                    audioSource.clip = unlocksound;
                    audioSource.Play();
                }    
            }
            if(locked)
            {
                audioSource.clip = locksound;
                audioSource.Play();
            }
        }
    }
}
