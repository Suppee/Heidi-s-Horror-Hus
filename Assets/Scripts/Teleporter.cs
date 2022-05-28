using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleporter : Interactable
{
    [SerializeField] Image blackSquare;
    [SerializeField] float transitionTime;
    [SerializeField] float fadeTime;
    [SerializeField] bool moonState;
    [SerializeField] Transform tpLocation;
    [SerializeField] GameObject outsideLight;


    public override void Interact()
    {        
        StartCoroutine(teleport());
    }

    public void OnTriggerEnter(Collider other)
    {
        playerController = other.GetComponent<PlayerController>();
        StartCoroutine(teleport());
    }

    IEnumerator teleport()
    {
        if (playerController != null)
            playerController.GetComponent<CharacterController>().enabled = false;

        yield return StartCoroutine(FadeToFromBlack(true, blackSquare));
        yield return new WaitForSeconds(transitionTime);

        outsideLight.SetActive(moonState);
        playerController.gameObject.transform.position = tpLocation.position;
        playerController.gameObject.transform.rotation = tpLocation.rotation;

        yield return StartCoroutine(FadeToFromBlack(false, blackSquare));

        if (playerController != null)
            playerController.GetComponent<CharacterController>().enabled = true;
    }

    IEnumerator FadeToFromBlack(bool fadeToBlack, Image blackSquare)
    {
        float fadeVal;

        if (fadeToBlack)
        {
            while (blackSquare.color.a < 1)
            {
                fadeVal = blackSquare.color.a + (fadeTime * Time.deltaTime);
                blackSquare.color = new Color(blackSquare.color.r, blackSquare.color.g, blackSquare.color.b, fadeVal);
                yield return null;
            }
        }
        else
        {
            while (blackSquare.color.a > 0)
            {
                fadeVal = blackSquare.color.a - (fadeTime * Time.deltaTime);
                blackSquare.color = new Color(blackSquare.color.r, blackSquare.color.g, blackSquare.color.b, fadeVal);
                yield return null;
            }
        }
    }
}
