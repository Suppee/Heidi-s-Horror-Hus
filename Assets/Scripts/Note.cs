using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : Interactable
{
    public GameObject noteImage;

    [SerializeField] private AudioClip ItemCollected;
    [SerializeField] private AudioSource audioSource;

    public GameObject noteLibrary;
    private SpriteRenderer noteReference;
    public string ID;

    private void Start()
    {
        noteImage.SetActive(false);
        noteReference = noteLibrary.transform.Find(ID).gameObject.GetComponent<SpriteRenderer>();
        if (noteReference != null)
            noteImage.GetComponent<Image>().sprite = noteReference.sprite;
    }

    public override void Interact()
    {
        if (noteImage.activeSelf == false)
        {
            noteImage.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(ItemCollected);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            playerController.canControl = false;
        }
        else
        {
            noteImage.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerController.canControl = true;
        }
    }
}
