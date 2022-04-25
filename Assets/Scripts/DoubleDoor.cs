using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : Interactable
{
    public bool locked;
    bool open;
    public bool canInteract;
    [SerializeField] private Animator leftAnim;
    [SerializeField] private Animator rightAnim;
    [SerializeField] private AudioClip locksound;
    [SerializeField] private AudioClip opensound;
    [SerializeField] private AudioClip closesound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string accesskey;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        canInteract = true;
    }
    public override void Interact()
    {
        if (!locked)
        {
            if (open && canInteract)
            {
                canInteract = false;
                audioSource.clip = closesound;
                audioSource.Play();
                leftAnim.Play("DoorCloseLeft", 0, 0.0f);
                rightAnim.Play("DoorCloseRight", 0, 0.0f);
                open = false;

            }
            else if (canInteract)
            {
                canInteract = false;
                leftAnim.Play("DoorOpenLeft", 0, 0f);
                rightAnim.Play("DoorOpenRight", 0, 0f);
                open = true;
                audioSource.clip = opensound;
                audioSource.Play();
            }

        }
        else if (locked && GetComponent<AudioSource>().isPlaying == false)
        {
            for (int i = 0; i < playerController.keyring.Count; i++)
            {
                if (playerController.keyring[i].keycode == accesskey)
                {
                    locked = false;
                    // ADD UNLOCKING SOUND
                }

            }
            if (locked)
            {
                audioSource.clip = locksound;
                audioSource.Play();
            }

        }



    }
}
