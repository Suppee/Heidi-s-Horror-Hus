using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] AudioClip[] dialogs;
    [SerializeField] AudioSource audioPlayer;
    
    public void PlayDialog(string clipName)
    {
        AudioClip foundClip = null;
        foreach (AudioClip dialog in dialogs)
        {
            if (dialog.name == clipName)
            {
                if (foundClip != null)
                {
                    throw new ArgumentException(clipName + " exists more than once in array \"dialogs\"");
                }

                foundClip = dialog;
            }
        }

        audioPlayer.clip = foundClip;
        audioPlayer.Play();
    }
}
