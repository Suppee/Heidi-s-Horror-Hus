using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool locked;
    bool open;
    [SerializeField] private Animator doorAnim;
    [SerializeField] private AudioClip locksound;
    [SerializeField] private AudioClip opensound;
    [SerializeField] private AudioClip closesound;
    [SerializeField] private AudioClip unlocksound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string accesskey;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        if (!locked)
        {
            if (open)
            {
                audioSource.clip = closesound;
                audioSource.Play();
                doorAnim.Play("DoorClose", 0, 0.0f);
                open = false;
                
            }
            else
            {
                doorAnim.Play("DoorOpen", 0, 0f);
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
