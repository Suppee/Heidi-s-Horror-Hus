using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Box : MonoBehaviour
{
    public GameObject Door;
    DoubleDoor doubleDoor;
    private bool tjek = true;

    public float waitTime;

    void Start()
    {
        doubleDoor = Door.GetComponent<DoubleDoor>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(tjek ==true)
        {
            doubleDoor.Interact();
            StartCoroutine("Wait");
        }
        else
        {

        }
    }

    private IEnumerator Wait()
    {
        tjek = false;
        yield return new WaitForSeconds(waitTime);
        
        tjek = true;
    }

}
