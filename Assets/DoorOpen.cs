using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from: https://www.youtube.com/watch?v=6vj_Ie9i-Ak&t=121s

public class DoorOpen : MonoBehaviour
{
    // takes a variable, a foreign gameobject
    [SerializeField] GameObject door;
    // [SerializeField] makes a variable changeable in the inspector.
    bool isOpen = false;

    // Once the player interacts with the pressure plate,
    // the door will open.
    void OnTriggerEnter(Collider col)
    {
        if (!isOpen)
        {
            isOpen = true;
            // the door moves with this command.   x, y, z
            door.transform.position += new Vector3(0, 3, 0);
        }
    }
}
