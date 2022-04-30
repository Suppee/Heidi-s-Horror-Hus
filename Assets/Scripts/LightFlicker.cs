using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flickering());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flickering()
    {
        while(true)
        {
            this.gameObject.transform.GetChild(0).GetComponent<Light>().enabled = false;
            timeDelay = Random.Range(0.01f, 2f);
            yield return new WaitForSeconds(timeDelay);
            this.gameObject.transform.GetChild(0).GetComponent<Light>().enabled = true;
            timeDelay = Random.Range(0.01f, 2f);
            yield return new WaitForSeconds(timeDelay);
        }
       
    }
}
