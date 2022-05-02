using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public float timeDelay;
    public List<Light> lights;
    public List<Light> specialLights;

    // Start is called before the first frame update
    void Start()
    {
        lights.AddRange(gameObject.GetComponentsInChildren<Light>());

        foreach (Light light in lights)
        {
            if (!specialLights.Contains(light))
            {
                StartCoroutine(Flickering(light));
            }
        }
    }
    IEnumerator Flickering(Light light)
    {
        while (true)
        {
            light.enabled = false;
            timeDelay = Random.Range(0.01f, 0.5f);
            yield return new WaitForSeconds(timeDelay);
            light.enabled = true;
            timeDelay = Random.Range(0.01f, 2f);
            yield return new WaitForSeconds(timeDelay);
        }
    }
}
