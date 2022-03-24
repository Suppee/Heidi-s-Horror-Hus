using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public string keycode;
    public override void Interact()
    {
        playerController.keyring.Add(this);
        gameObject.SetActive(false);
    }

}
