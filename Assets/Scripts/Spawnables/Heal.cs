using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    public float heal = 40f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FindObjectOfType<HealthManager>().healthAmount < 100)
            {
                FindObjectOfType<HealthManager>().healPlayer(heal);

                Destroy(this.gameObject);
            }
        }
    }

}
