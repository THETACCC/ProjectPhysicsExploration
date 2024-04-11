using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLogicVertical : MonoBehaviour
{
    public Rigidbody rb;
    public float pushMagnitude = 1250f;

    public float minY = 0f; // Minimum Y-axis value
    public float maxY = 10f; // Maximum Y-axis value
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
 
            if (rb.velocity.magnitude < 1f) // Using 0.01 as a threshold for being "stationary"
            {
                if (other.gameObject.tag == "GravityBullet")
                {
                    Debug.Log("EnterTrigger");

                    //Vector3 closestPointOnBullet = other.ClosestPoint(transform.position);
                    //Vector3 directionFromBullet = transform.position - closestPointOnBullet;
                    Vector3 directionFromBullet = -other.transform.forward;
                    directionFromBullet.Normalize();

                    rb.AddForce(Vector3.up * pushMagnitude);
                    Destroy(other.gameObject);
                }
                else if (other.gameObject.tag == "KineticBullet")
                {
                    Debug.Log("EnterTrigger");

                    //Vector3 closestPointOnBullet = other.ClosestPoint(transform.position);
                    //Vector3 directionFromBullet = transform.position - closestPointOnBullet;
                    Vector3 directionFromBullet = -other.transform.forward;
                    directionFromBullet.Normalize();

                    rb.AddForce(-Vector3.up * pushMagnitude);
                    Destroy(other.gameObject);
                }
                else if (other.gameObject.tag == "LiftBullet")
                {
                    Debug.Log("EnterTrigger");


                    rb.AddForce(Vector3.up * pushMagnitude);
                    Destroy(other.gameObject);
                }
            }


    }



    void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        transform.position = currentPosition;
    }
}

