using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float timeDelay;
    Light[] myLights;

    // Start is called before the first frame update
    void Start()
    {
        myLights = gameObject.GetComponentsInChildren<Light>();

        foreach (Light light in myLights)
        {
            StartCoroutine(Flickering(light));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flickering(Light light)
    {
        while(true)
        {
            light.enabled = false;
            timeDelay = Random.Range(0.01f, 2f);
            yield return new WaitForSeconds(timeDelay);
            light.enabled = true;
            timeDelay = Random.Range(0.01f, 2f);
            yield return new WaitForSeconds(timeDelay);
        }
       
    }
}
