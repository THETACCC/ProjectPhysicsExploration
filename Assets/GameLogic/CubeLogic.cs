using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    public Rigidbody rb;
    public float pushMagnitude = 1250f;
    [HideInInspector]
    public bool isMoving = false;
    public float movementThreshold = 0.1f;

    void Start()
    {

    }


    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        // Check if the Rigidbody's velocity magnitude is greater than the movementThreshold
        if (rb.velocity.magnitude > movementThreshold)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GravityBullet")
        {
            Debug.Log("EnterTrigger");
            SoundSystem.instance.PlaySound("BulletImpact");
            //Vector3 closestPointOnBullet = other.ClosestPoint(transform.position);
            //Vector3 directionFromBullet = transform.position - closestPointOnBullet;
            Vector3 directionFromBullet = -other.transform.forward;
            directionFromBullet.Normalize();

            rb.AddForce(directionFromBullet * pushMagnitude);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "KineticBullet")
        {
            Debug.Log("EnterTrigger");
            SoundSystem.instance.PlaySound("BulletImpact");
            //Vector3 closestPointOnBullet = other.ClosestPoint(transform.position);
            //Vector3 directionFromBullet = transform.position - closestPointOnBullet;
            Vector3 directionFromBullet = -other.transform.forward;
            directionFromBullet.Normalize();

            rb.AddForce(-directionFromBullet * pushMagnitude);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "LiftBullet")
        {
            Debug.Log("EnterTrigger");
            SoundSystem.instance.PlaySound("BulletImpact");

            rb.AddForce(Vector3.up * pushMagnitude);
            Destroy(other.gameObject);
        }
    }
}
