using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform BulletSpawner;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100;

    public float shootingCooldown = 0.5f; //delay between shots
    private float coolDownTimer = 0f; //timer to track cooldown

    public AudioSource Shooting;

    private void Start()
    {
        Shooting.volume = .4f;
    }
    // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && coolDownTimer <= 0f)
        {
            var bullet = Instantiate(bulletPrefab, BulletSpawner.position, BulletSpawner.rotation);
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawner.forward * bulletSpeed;
            Shooting.Play();

            coolDownTimer = shootingCooldown;
        }
    }
}
