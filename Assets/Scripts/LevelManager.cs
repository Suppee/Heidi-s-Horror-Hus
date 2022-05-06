using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Interactable
{
    public Animator transition;
    public float transitionTime = 1f;

    public override void Interact()
    {
        transition.SetTrigger("Start");
        new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
