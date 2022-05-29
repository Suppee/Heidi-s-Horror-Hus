using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chair : Interactable
{
    [SerializeField] Image blackSquare;

    public enum TriggerType { OneTime, OneTimeSequence };

    [Header("Trigger Mode")]
    public TriggerType triggerMode;

    [Header("One Time Trigger Settings")]
    public UnityEvent onetimeEvents;

    [Header("Sequence Trigger Settings")]
    public List<UnityEvent> sequenceEvents;
    public List<float> sequenceTiming;
    bool firstTime = true;

    public override void Interact()
    {
        if (firstTime)
        {
            firstTime = false;
            switch (triggerMode)
            {
                case TriggerType.OneTime:
                    onetimeEvents.Invoke();
                    break;

                case TriggerType.OneTimeSequence:
                    StartCoroutine(Sequence());
                    break;

                default:
                    break;
            }
        }
    }

    IEnumerator Sequence()
    {
        for (int i = 0; i < sequenceEvents.Count; i++)
        {
            yield return new WaitForSeconds(sequenceTiming[i]);
            sequenceEvents[i].Invoke();
        }
    }

    public void SleepNow()
    {
        StartCoroutine(GoToSleep());
    }

    IEnumerator GoToSleep()
    {
        blackSquare.color = new Color(blackSquare.color.r, blackSquare.color.g, blackSquare.color.b, 1);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu");
    }
}
