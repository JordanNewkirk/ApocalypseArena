using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int maxHealth;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<scorescript>().raiseScore();
        }
    }
}
