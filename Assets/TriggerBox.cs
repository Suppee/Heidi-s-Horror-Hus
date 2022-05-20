using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    public UnityEvent triggerFunction;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        triggerFunction.Invoke(); 
    }
}
