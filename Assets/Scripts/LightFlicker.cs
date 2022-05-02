using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float timeDelay;
    public enum lightSetting { StaticOn, StaticOff, Flickering}
    public lightSetting lightMode;

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
            switch(lightMode)
            {
                case lightSetting.StaticOn:
                    this.gameObject.transform.GetChild(0).GetComponent<Light>().enabled = true;
                    break;

                case lightSetting.StaticOff:
                    this.gameObject.transform.GetChild(0).GetComponent<Light>().enabled = false;
                    break;

                case lightSetting.Flickering:
                    this.gameObject.transform.GetChild(0).GetComponent<Light>().enabled = false;
                    timeDelay = Random.Range(0.01f, 0.5f);
                    yield return new WaitForSeconds(timeDelay);
                    this.gameObject.transform.GetChild(0).GetComponent<Light>().enabled = true;
                    timeDelay = Random.Range(0.01f, 2f);
                    yield return new WaitForSeconds(timeDelay);
                    break;
            }
            
        }
       
    }
}
