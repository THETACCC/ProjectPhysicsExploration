using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private float agentWalkSpeed = 0f;

    //Death Effects
    public GameObject replacement;

    public Transform teleportationPoint;

    //Reference to Camera
    public GameObject Vcam;
    public CameraFade cameraFade;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Vcam = GameObject.FindGameObjectWithTag ("MainVcam");
        cameraFade = Vcam.GetComponent<CameraFade>();

        animator = GetComponentInChildren<Animator>();
        agentWalkSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
            //.SetBool("Chase", false);
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            //animator.SetBool("Chase", true);
        }

        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        float AnimMagnitude = Mathf.Clamp01(agent.velocity.magnitude);
        animator.SetFloat("Speed", agent.velocity.magnitude, 0.05f, Time.deltaTime);


    }

    private void Patroling()
    {
        agent.speed = agentWalkSpeed;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        Debug.Log("Patrolling");
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        agent.speed = 18f;
    }

    private void AttackPlayer()
    {

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            PlayerController playercontroll = player.GetComponent<PlayerController>();
            if (playercontroll != null)
            {
                Invoke("TriggerCameraShake", .5f);

            }


            Debug.Log("ATTACK!!");
            animator.SetTrigger("Attack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void TriggerCameraShake()
    {
        PlayerController playercontroll = player.GetComponent<PlayerController>();
        CineMachineShake.Instance.ShakeCamera(2.5f, 0.5f);
        playercontroll.PlayerHealth -= 25;
        if (playercontroll.PlayerHealth <= 0)
        {
            cameraFade.ResetPlayer();
            player.transform.position = teleportationPoint.position;
            playercontroll.ResetHealth();
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            CubeLogic cubelogic = collision.gameObject.GetComponent<CubeLogic>();
            if (cubelogic != null)
            {
                if(cubelogic.isMoving)
                {  
                    var _replacement = Instantiate(replacement,transform.position,transform.rotation);  
                    var rbs = _replacement.GetComponentsInChildren<Rigidbody>();

                    foreach(var rb in rbs)
                    {
                        rb.AddExplosionForce(collision.relativeVelocity.magnitude * 50, collision.contacts[0].point, 2);
                    }


                    DestroyEnemy();
                    Debug.Log("Being hit");
                }
            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
