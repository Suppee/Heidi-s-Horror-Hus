using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] AudioClip[] dialogs;
    [SerializeField] AudioClip startDialog;
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] TextMeshProUGUI debugText;
    int dialogTimer;

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

    public void SetTimer(int timer)
    {
        dialogTimer = timer;
    }

    public void DebugDialog(string dialog)
    {
        StartCoroutine(PrintDebugDialog(dialog, dialogTimer));
    }

    IEnumerator PrintDebugDialog(string dialog, int dialogTimer)
    {
        debugText.SetText(dialog);
        yield return new WaitForSeconds(dialogTimer);
        debugText.SetText("");
    }
}
