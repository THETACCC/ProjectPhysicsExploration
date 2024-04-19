using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool isActivate = false;
    private bool hasStarted = false;
    void Update()
    {
        if (isActivate && !hasStarted)
        {
            StartSpawning();
            hasStarted = true; // Set hasStarted to true to avoid repeated starts
        }
        else if (!isActivate && hasStarted)
        {
            StopSpawning();
            hasStarted = false; // Reset hasStarted when spawning is stopped
        }
    }
    public void StartSpawning()
    {
        // Prevent multiple calls to InvokeRepeating
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0f, 5f);  // 0f delay, repeat every 5 seconds
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }
    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Instantiate the block at the position and rotation of this spawner
            Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), transform.rotation);
        }
        else
        {
            Debug.LogError("Block prefab is not assigned!");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "KineticBullet" || collision.gameObject.tag == "LiftBullet" || collision.gameObject.tag == "GravityBullet")
        {
            Destroy(this.gameObject);
        }
    }
}
