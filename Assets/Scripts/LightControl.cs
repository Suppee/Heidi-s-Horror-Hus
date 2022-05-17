using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public float timeDelay;
    public bool lightsOn;
    public LightState startState;
    public List<Light> lights;
    public List<Light> specialLights;

    public enum LightState
    {
        turnedOn,
        turnedOff,
        flickering
    }

    // Start is called before the first frame update
    void Awake()
    {
        lights.AddRange(gameObject.GetComponentsInChildren<Light>());

        ChangeState(startState);
    }

    public void ChangeState(LightState lightState)
    {
        foreach (Light light in lights)
        {
            if (!specialLights.Contains(light))
            {
                if (lightState == LightState.turnedOn)
                {
                    StopAllCoroutines();
                    light.enabled = true;
                }

                if (lightState == LightState.turnedOff)
                {
                    StopAllCoroutines();
                    light.enabled = false;
                }

                if (lightState == LightState.flickering)
                {
                    StartCoroutine(Flickering(light));
                }
            }
        }
    }

    public IEnumerator Flickering(Light light)
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
