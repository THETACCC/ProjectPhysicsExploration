using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFollow : MonoBehaviour
{
    public GameObject objectToFollow;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        gameObject.transform.position = objectToFollow.transform.position;
    }
}
