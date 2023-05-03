using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            Destroy(gameObject);
            var healthComponent = collision.GetComponent<health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }
}
