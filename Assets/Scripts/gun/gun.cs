using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform BulletSpawner;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100;

    public AudioSource Shooting;

    private void Start()
    {
        Shooting.volume = .4f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, BulletSpawner.position, BulletSpawner.rotation);
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawner.forward * bulletSpeed;
            Shooting.Play();
        }
    }
}
