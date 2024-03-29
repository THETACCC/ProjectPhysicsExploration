using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the R key was pressed down this frame
        if (Input.GetKeyDown(KeyCode.R))
        {
            // If R is pressed, set the "Run" bool to true
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            // If R is released, set the "Run" bool to false
            animator.SetBool("Run", false);
        }
    }
}
