using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteracteable
{
    [SerializeField]Vector3 openDoorPos;
    public void Interact()
    {
        transform.eulerAngles = openDoorPos;
    }

}
