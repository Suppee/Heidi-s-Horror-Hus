using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : Interactable
{
    public bool locked;
    bool open;
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
        leftAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        rightAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }
    public override void Interact()
    {
        if (!locked)
        {
            if (open)
            {
                audioSource.clip = closesound;
                audioSource.Play();
                leftAnim.Play("DoorClose", 0, 0.0f);
                rightAnim.Play("DoorClose", 0, 0.0f);
                open = false;

            }
            else
            {
                leftAnim.Play("DoorOpen", 0, 0f);
                //rightAnim.Play("DoorOpen", 0, 0f);
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
