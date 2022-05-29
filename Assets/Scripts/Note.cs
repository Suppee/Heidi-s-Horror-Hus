using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : Interactable
{
    [SerializeField] AudioClip ItemCollected;
    [SerializeField] Sprite noteImage;
    [SerializeField] GameObject noteUI;
    Image noteDisplay;
    AudioSource audioSource;

    private void Awake()
    {
        noteDisplay = noteUI.GetComponent<Image>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (noteUI.activeSelf == false)
        {
            Button noteButton = noteUI.GetComponent<Button>();
            noteButton.onClick.RemoveAllListeners();
            noteButton.onClick.AddListener(Interact);
            print(noteUI.GetComponent<Button>().onClick.GetPersistentEventCount());

            noteUI.SetActive(true);
            noteDisplay.sprite = noteImage;
            audioSource.PlayOneShot(ItemCollected);

            playerController.canControl = false;
            playerController.moveValue = Vector2.zero;
        }
        else
        {
            noteUI.SetActive(false);

            playerController.canControl = true;
        }
    }
}
