using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLogicVertical : MonoBehaviour
{
    public Rigidbody rb;
    public float pushMagnitude = 1250f;

    public float minY = 0f; // Minimum Y-axis value
    public float maxY = 10f; // Maximum Y-axis value
    public float movementSpeed = 5f;
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        /*
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
     */
        if (rb.velocity.magnitude < 1f) // Using 1f as a threshold for being "stationary"
        {
            float targetY = 0f;

            if (other.gameObject.tag == "GravityBullet")
            {
                Vector3 directionFromBullet = -other.transform.forward;
                directionFromBullet.Normalize();

                print(directionFromBullet);
                if(directionFromBullet.y < 0)
                {
                    targetY = minY;
                }
                else
                {
                    targetY = maxY;
                }

                Destroy(other.gameObject);
            }
            else if (other.gameObject.tag == "KineticBullet")
            {
                Vector3 directionFromBullet = -other.transform.forward;
                directionFromBullet.Normalize();

                print(directionFromBullet);
                if (directionFromBullet.y > 0)
                {
                    targetY = minY;
                }
                else
                {
                    targetY = maxY;
                }

                Destroy(other.gameObject);
            }
            else if (other.gameObject.tag == "LiftBullet")
            {
                Debug.Log("EnterTrigger: LiftBullet");
                targetY = maxY;
            }

            if (targetY != 0f) // Check if targetY was set
            {
                StartCoroutine(MoveToHeight(targetY));
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator MoveToHeight(float targetY)
    {
        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            Vector3 newPosition = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, movementSpeed * Time.deltaTime), transform.position.z);
            rb.MovePosition(newPosition);
            yield return null;
        }
    }

    void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        transform.position = currentPosition;
    }
}

