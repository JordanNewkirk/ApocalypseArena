using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    private Animator anim;
    private NavMeshAgent agent;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            agent.velocity = Vector3.zero;
            Destroy(gameObject, 2.2f);
        }
        
    }
}
