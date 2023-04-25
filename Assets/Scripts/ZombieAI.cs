using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    public int damageToGive = 1;

    void Start()
    {
        //Debug.Log("Player: " + player.name);
        damageToGive = 1;
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent.SetDestination(player.position);
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

