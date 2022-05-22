using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : Interactable
{
    public Animator transition;
    public float transitionTime;
    public Transform tpLocation;
    public GameObject outsideLight;

    public override void Interact()
    {        
        StartCoroutine(teleport());
    }

    IEnumerator teleport()
    {
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        playerController.GetComponent<CharacterController>().enabled = false;
        outsideLight.SetActive(true);
        playerController.gameObject.transform.position = tpLocation.position;
        playerController.gameObject.transform.rotation = tpLocation.rotation;
    }
}
