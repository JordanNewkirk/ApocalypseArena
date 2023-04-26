using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 2;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
