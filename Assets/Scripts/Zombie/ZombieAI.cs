using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Animator anim;

    public float damageToGive = 20f;

    public float randomMoveInterval = 10f; // Interval for random movements
    private float randomMoveTimer; // Timer for tracking random movement intervals
    private bool isRandomMoving; // Flag for indicating random movement

    private Vector3 randomDestination; // Random destination for movement

    private bool isDead;


    void Start()
    {
        damageToGive = 20f;
        randomMoveTimer = randomMoveInterval;

    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (!isRandomMoving)
        {
            // Always move towards the player
            agent.SetDestination(player.position);
        }
        
       
        // Check if it's time for a random movement
        randomMoveTimer -= Time.deltaTime;
        if (randomMoveTimer <= 0f)
        {
            // Toggle random movement on/off
            isRandomMoving = !isRandomMoving;

            if (isRandomMoving)
            {
                // Generate a random destination
                randomDestination = GenerateRandomDestination();
                agent.SetDestination(randomDestination);
                anim.SetBool("isRunning", true);
            }
            else
            {
                // Resume moving towards the player
                agent.SetDestination(player.position);
                anim.SetBool("isRunning", false);
            }

            // Reset the random movement timer
            randomMoveTimer = Random.Range(randomMoveInterval * 0.5f, randomMoveInterval * 1.5f);

            
        }

        // Update animator parameter for speed
        float speed = agent.velocity.magnitude;
        anim.SetFloat("Speed", speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            FindObjectOfType<HealthManager>().hurtPlayer(damageToGive, hitDirection);
        }
    }

    // Generate a random destination within a certain range
    private Vector3 GenerateRandomDestination()
    {
        float randomX = Random.Range(-50f, 50f);
        float randomZ = Random.Range(-50f, 50f);
        Vector3 randomDirection = new Vector3(randomX, 0f, randomZ);
        return player.position + randomDirection;
    }
}



