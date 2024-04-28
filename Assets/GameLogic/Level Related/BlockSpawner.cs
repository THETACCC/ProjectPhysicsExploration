using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;

    void Start()
    {

    }

    public void SpawnBlock()
    {
        SoundSystem.instance.PlaySound("SpawnBlock");
        if (blockPrefab != null)
        {
            // Instantiate the block at the position and rotation of this spawner
            Instantiate(blockPrefab, new Vector3 (transform.position.x, transform.position.y + 2f, transform.position.z), transform.rotation);
        }
        else
        {
            Debug.LogError("Block prefab is not assigned!");
        }
    }
}
