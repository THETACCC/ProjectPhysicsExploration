using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLogic : MonoBehaviour
{

     public Rigidbody rb;
     public float pushMagnitude = 1250f;
     public PlatformType type;


     public float minMove = 0f; // Minimum Y-axis value
     public float maxMove = 10f; // Maximum Y-axis value
     public float movementSpeed = 5f;


     public float movementThreshold = 0.01f; // Minimum distance to consider as movement
     private Vector3 lastPosition;
     private bool isMoving;
     void Start()
     {
         lastPosition = transform.position;
     }


     void Update()
     {
         float distanceMoved = Vector3.Distance(lastPosition, transform.position);
         if (distanceMoved > movementThreshold)
         {
             isMoving = true;
             Debug.Log("Object is moving");
         }
         else
         {
             isMoving = false;
             Debug.Log("Object is stationary");
         }
         lastPosition = transform.position;
     }

     private void OnTriggerEnter(Collider other)
     {
         /*
         if(type == PlatformType.Vertical)
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

                     rb.AddForce(directionFromBullet * pushMagnitude);
                     Destroy(other.gameObject);
                 }
                 else if (other.gameObject.tag == "KineticBullet")
                 {
                     Debug.Log("EnterTrigger");

                     //Vector3 closestPointOnBullet = other.ClosestPoint(transform.position);
                     //Vector3 directionFromBullet = transform.position - closestPointOnBullet;
                     Vector3 directionFromBullet = -other.transform.forward;
                     directionFromBullet.Normalize();

                     rb.AddForce(directionFromBullet * pushMagnitude);
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
         else if (type == PlatformType.Xmove)
         {
             if (other.gameObject.tag == "GravityBullet")
             {
                 Debug.Log("EnterTrigger");

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

                 //Vector3 closestPointOnBullet = other.ClosestPoint(transform.position);
                 //Vector3 directionFromBullet = transform.position - closestPointOnBullet;
                 Vector3 directionFromBullet = -other.transform.forward;
                 directionFromBullet.Normalize();

                 rb.AddForce(-directionFromBullet * pushMagnitude);
                 Destroy(other.gameObject);
             }
             else if (other.gameObject.tag == "LiftBullet")
             {

                 Destroy(other.gameObject);
             }
         }
         else if (type == PlatformType.Zmove)
         {
             if (other.gameObject.tag == "GravityBullet")
             {
                 Debug.Log("EnterTrigger");

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

                 //Vector3 closestPointOnBullet = other.ClosestPoint(transform.position);
                 //Vector3 directionFromBullet = transform.position - closestPointOnBullet;
                 Vector3 directionFromBullet = -other.transform.forward;
                 directionFromBullet.Normalize();

                 rb.AddForce(-directionFromBullet * pushMagnitude);
                 Destroy(other.gameObject);
             }
             else if (other.gameObject.tag == "LiftBullet")
             {
                 Destroy(other.gameObject);
             }
         }
         */

         if (rb.velocity.magnitude < 1f) // Using 1f as a threshold for being "stationary"
         {
             float target = 0f;

             if (other.gameObject.tag == "GravityBullet")
             {
                 Vector3 directionFromBullet = -other.transform.forward;
                 directionFromBullet.Normalize();

                 print(directionFromBullet);
                 if (directionFromBullet.y < 0)
                 {
                     target = minMove;
                 }
                 else
                 {
                     target = maxMove;
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
                     target = minMove;
                 }
                 else
                 {
                     target = maxMove;
                 }

                 Destroy(other.gameObject);
             }
             else if (other.gameObject.tag == "LiftBullet")
             {
                 Debug.Log("EnterTrigger: LiftBullet");

                 Destroy(other.gameObject);
             }

             if (target != 0f) // Check if targetY was set
             {
                 StartCoroutine(MoveToHeight(target));
                 Destroy(other.gameObject);
             }
         }


     }


     private IEnumerator MoveToHeight(float target)
     {
         if(type == PlatformType.Vertical)
         {
             while (Mathf.Abs(transform.position.y - target) > 0.01f)
             {
                 Vector3 newPosition = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, target, movementSpeed * Time.deltaTime), transform.position.z);
                 rb.MovePosition(newPosition);
                 yield return null;
             }
         }
         else if (type == PlatformType.Zmove)
         {
             while (Mathf.Abs(transform.position.z - target) > 0.01f)
             {
                 Vector3 newPosition = new Vector3(transform.position.x, transform.position.y,Mathf.MoveTowards(transform.position.z, target, movementSpeed * Time.deltaTime));
                 rb.MovePosition(newPosition);
                 yield return null;
             }
         }
         else if (type == PlatformType.Xmove)
         {
             while (Mathf.Abs(transform.position.x - target) > 0.01f)
             {
                 Vector3 newPosition = new Vector3(Mathf.MoveTowards(transform.position.x, target, movementSpeed * Time.deltaTime), transform.position.y,transform.position.z );
                 rb.MovePosition(newPosition);
                 yield return null;
             }
         }
     }

     void LateUpdate()
     {
         if(type == PlatformType.Zmove)
         {
             Vector3 currentPosition = transform.position;
             currentPosition.z = Mathf.Clamp(currentPosition.z, minMove, maxMove);
             transform.position = currentPosition;
         }
         else if (type == PlatformType.Xmove)
         {
             Vector3 currentPosition = transform.position;
             currentPosition.x = Mathf.Clamp(currentPosition.x, minMove, maxMove);
             transform.position = currentPosition;
         }
         else if (type == PlatformType.Vertical)
         {
             Vector3 currentPosition = transform.position;
             currentPosition.y = Mathf.Clamp(currentPosition.y, minMove, maxMove);
             transform.position = currentPosition;
         }
     }

}

public enum PlatformType
{
    Vertical,
    Xmove,
    Zmove
}
