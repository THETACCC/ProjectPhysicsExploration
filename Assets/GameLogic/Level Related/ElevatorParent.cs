using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorParent : MonoBehaviour
{
    PlayerMovementAdvanced movement;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent.SetParent(transform);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.SetParent(null);
        }

    }
}
