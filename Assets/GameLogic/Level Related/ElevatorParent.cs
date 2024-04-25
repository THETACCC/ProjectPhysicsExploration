using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorParent : MonoBehaviour
{
    PlayerMovementAdvanced movement;
    private Transform ElevatorOBJ;
    private Rigidbody myRB;
    public void Start()
    {
        ElevatorOBJ = this.gameObject.transform.GetChild(0); // Get first child
        myRB = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            other.transform.parent.SetParent(transform);



        }

    }
    public void OnTriggerStay(Collider other)
    {

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.SetParent(null);
        }

    }
}
