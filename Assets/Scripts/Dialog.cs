using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] AudioClip[] dialogs;
    [SerializeField] AudioClip startDialog;
    [SerializeField] AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer.clip = startDialog;
        audioPlayer.PlayDelayed(2);
    }

    public void PlayDialog(AudioClip dialog)
    {
        audioPlayer.clip = dialog;
        audioPlayer.Play();
    }
}
