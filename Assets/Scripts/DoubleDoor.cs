using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoubleDoor : Interactable
{
    public enum TriggerType { OneTime, OneTimeSequence, RandomRepeating };

    [Header("Trigger Mode")]
    public TriggerType triggerMode;

    [Header("One Time Trigger Settings")]
    public UnityEvent onetimeEvents;

    [Header("Sequence Trigger Settings")]
    public List<UnityEvent> sequenceEvents;
    public List<float> sequenceTiming;
    bool firstTime = true;

    public bool locked;
    bool open;
    public bool canInteract;
    [SerializeField] private Animator leftAnim;
    [SerializeField] private Animator rightAnim;
    [SerializeField] private AudioClip locksound;
    [SerializeField] private AudioClip unlocksound;
    [SerializeField] private AudioClip opensound;
    [SerializeField] private AudioClip closesound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string accesskey;
    public bool startOpen;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        canInteract = true;
        if (startOpen)
            OpenDoor();
    }
    public override void Interact()
    {
        if (!locked)
        {
            if (open && canInteract)
            {
                CloseDoor();

            }
            else if (canInteract)
            {
                OpenDoor();
            }

        }
        else if (locked && GetComponent<AudioSource>().isPlaying == false)
        {
            for (int i = 0; i < playerController.keyring.Count; i++)
            {
                if (playerController.keyring[i].keycode == accesskey)
                {
                    UnlockDoor();
                }
            }

            if (locked)
            {
                audioSource.clip = locksound;
                audioSource.Play();
            }
        }

        EventCheck();
    }

    public void LockDoor()
    {
        locked = true;
    }

    public void UnlockDoor()
    {
        locked = false;
        audioSource.clip = unlocksound;
        audioSource.Play();
    }

    public void OpenDoor()
    {
        canInteract = false;
        leftAnim.Play("DoorOpenLeft", 0, 0f);
        rightAnim.Play("DoorOpenRight", 0, 0f);
        open = true;
        audioSource.clip = opensound;
        audioSource.Play();
    }

    public void CloseDoor()
    {
        canInteract = false;
        audioSource.clip = closesound;
        audioSource.Play();
        leftAnim.Play("DoorCloseLeft", 0, 0.0f);
        rightAnim.Play("DoorCloseRight", 0, 0.0f);
        open = false;
    }

    void EventCheck()
    {
        if (firstTime)
        {
            firstTime = false;
            switch (triggerMode)
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
    }

    IEnumerator Sequence()
    {
        for (int i = 0; i < sequenceEvents.Count; i++)
        {
            yield return new WaitForSeconds(sequenceTiming[i]);
            sequenceEvents[i].Invoke();
        }
        Destroy(this);
    }
}
