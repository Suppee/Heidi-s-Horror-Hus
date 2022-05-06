using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Interactable
{
    public Animator transition;
    public float transitionTime = 1f;
    public string sceneName;

    public override void Interact()
    {
        
        StartCoroutine(load());

    }

    IEnumerator load()
    {
        Scene sceneref = SceneManager.GetSceneByName(sceneName);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
        SceneManager.MoveGameObjectToScene(playerController.gameObject, sceneref);
    }
}
