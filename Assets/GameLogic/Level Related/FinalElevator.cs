using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalElevator : MonoBehaviour
{
    public GameObject FinalTeleportation;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {


            FinalTeleportation.SetActive(true);


        }

    }
}
