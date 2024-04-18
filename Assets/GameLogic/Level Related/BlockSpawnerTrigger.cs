using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerTrigger : MonoBehaviour
{
    public BlockSpawner spawner;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            spawner.SpawnBlock();
        }
    }
}
