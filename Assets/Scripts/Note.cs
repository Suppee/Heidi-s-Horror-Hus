using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : Interactable
{
    [SerializeField] AudioClip ItemCollected;
    [SerializeField] Sprite noteImage;
    [SerializeField] GameObject noteUI;
    SpriteRenderer noteDisplay;
    AudioSource audioSource;

    private void Awake()
    {
        noteDisplay = noteUI.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (noteUI.activeSelf == false)
        {
            noteUI.SetActive(true);
            noteDisplay.sprite = noteImage;
            audioSource.PlayOneShot(ItemCollected);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            playerController.canControl = false;
            playerController.moveValue = Vector2.zero;
        }
        else
        {
            noteUI.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerController.canControl = true;
        }
    }
}
