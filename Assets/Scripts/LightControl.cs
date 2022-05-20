using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    private float timeDelay;
    [SerializeField] private LightState startState;
    [SerializeField] private List<Light> lights;
    [SerializeField] private List<Light> specialLights;

    public enum LightState
    {
        on,
        off,
        flicker
    }

    // Start is called before the first frame update
    void Awake()
    {
        lights.AddRange(gameObject.GetComponentsInChildren<Light>());

        ChangeState(startState.ToString());
    }

    public void ChangeState(string lightState)
    {
        foreach (Light light in lights)
        {
            if (!specialLights.Contains(light))
            {
                switch (lightState)
                {
                    case "on":
                        StopAllCoroutines();
                        light.enabled = true;
                        break;
                    case "off":
                        StopAllCoroutines();
                        light.enabled = false;
                        break;
                    case "flicker":
                        StartCoroutine(Flickering(light));
                        break;
                    default:
                        StopAllCoroutines();
                        light.enabled = false;
                        break;
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
