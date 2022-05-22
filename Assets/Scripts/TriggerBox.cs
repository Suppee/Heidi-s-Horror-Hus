using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{

    public enum TriggerType { OneTime, OneTimeSequence, RandomRepeating};

    [Header("Trigger Mode")]
    public TriggerType triggerMode;

    [Header("One Time Trigger Settings")]
    public UnityEvent onetimeEvents;

    [Header("Sequence Trigger Settings")]
    public List<UnityEvent> sequenceEvents;
    public List<float> sequenceTiming;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        switch(triggerMode)
        {
            case TriggerType.OneTime:
                onetimeEvents.Invoke();
                Destroy(this);
                break;

            case TriggerType.OneTimeSequence:
                StartCoroutine(Sequence());
                break;

            case TriggerType.RandomRepeating:
                break;

            default:
                break;
        }
    }

    IEnumerator Sequence()
    {
        for(int i = 0; i < sequenceEvents.Count; i++)
        {
            yield return new WaitForSeconds(sequenceTiming[i]);
            sequenceEvents[i].Invoke();
        }
        Destroy(this);
    }
}
