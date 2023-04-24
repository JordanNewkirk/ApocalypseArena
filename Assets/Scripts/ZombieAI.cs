using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public int damageToGive = 1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        damageToGive = 1;
    }

    void Update()
    {
         agent.SetDestination(player.position); 
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

