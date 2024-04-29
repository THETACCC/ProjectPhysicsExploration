using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCheat : MonoBehaviour
{
    public Transform Area1Spawn;    
    public Transform Area2Spawn;
    public Transform Area3Spawn;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            player.transform.position = Area1Spawn.position;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            player.transform.position = Area2Spawn.position;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            player.transform.position = Area3Spawn.position;
        }
    }
}
