using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool isActivate = false;
    private bool hasStarted = false;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public Transform EnemyTeleportationPoint;
    void Update()
    {
        activeEnemies.RemoveAll(item => item == null); // Clean up null references

        if (isActivate && !hasStarted && activeEnemies.Count < 6)
        {
            StartSpawning();
            hasStarted = true;
        }
        else if (!isActivate && hasStarted || activeEnemies.Count >= 6)
        {
            StopSpawning();
            hasStarted = false;
        }
    }

    public void StartSpawning()
    {
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0f, 5f);  // Start immediately and repeat every 5 seconds
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }

    public void SpawnEnemy()
    {
        if (activeEnemies.Count < 6) // Check if less than 6 enemies are active
        {
            if (enemyPrefab != null)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), transform.rotation);
                EnemyAI newEnemyAI = newEnemy.GetComponent<EnemyAI>();
                if(newEnemyAI != null)
                {
                    newEnemyAI.teleportationPoint = EnemyTeleportationPoint;
                }
                activeEnemies.Add(newEnemy); // Add the new enemy to the list
            }
            else
            {
                Debug.LogError("Enemy prefab is not assigned!");
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KineticBullet" || collision.gameObject.tag == "LiftBullet" || collision.gameObject.tag == "GravityBullet")
        {
            Destroy(this.gameObject);
        }
    }
}