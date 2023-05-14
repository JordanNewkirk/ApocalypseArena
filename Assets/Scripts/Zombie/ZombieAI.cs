using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    public float damageToGive = 20f;

    public Animator anim;

    private bool isChasing = false;
    public float chaseDistance = 75f;


    void Start()
    {
        //Debug.Log("Player: " + player.name);
        damageToGive = 20f;
      
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
            anim.SetBool("isRunning", true);
        }
        else
        {
            isChasing = false;
            anim.SetBool("isRunning", false);
        }

        if(isChasing)
        {
            agent.SetDestination(player.position);
        }
        //Debug.Log("Zombies heading to player position: " + player.position);

    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            FindObjectOfType<HealthManager>().hurtPlayer(damageToGive, hitDirection);
        }
        
    }
}

