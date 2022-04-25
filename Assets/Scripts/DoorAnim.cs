using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    Door door;
    DoubleDoor doubleDoor;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.gameObject.GetComponent<DoubleDoor>())
            doubleDoor = transform.parent.gameObject.GetComponent<DoubleDoor>();

        if (transform.parent.gameObject.GetComponent<Door>())
            door = transform.parent.gameObject.GetComponent<Door>();
    }

    public void Doorstate ()
    {
        if (door)
            door.canInteract = true;

        if (doubleDoor)
            doubleDoor.canInteract = true;
    }
}
