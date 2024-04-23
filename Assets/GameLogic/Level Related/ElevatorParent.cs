using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorParent : MonoBehaviour
{
    PlayerMovementAdvanced movement;
    private Transform ElevatorOBJ;

    public void Start()
    {
        ElevatorOBJ = this.gameObject.transform.GetChild(0); // Get first child

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
