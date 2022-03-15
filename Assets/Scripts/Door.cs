using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public override void Interact()
    {
        if(GetComponent<AudioSource>().isPlaying == false)
        GetComponent<AudioSource>().Play();
        
        
    }
}
