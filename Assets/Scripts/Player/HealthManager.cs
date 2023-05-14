using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{


    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCount;
    public float flashLength = 0.1f;

    public Image healthDisplay;
    public float healthAmount = 100f;

    private Animator anim;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCount -= Time.deltaTime;
            if(flashCount <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCount = flashLength;
            }
            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }

    public void hurtPlayer(float damage, Vector3 direction)
    {
        if(invincibilityCounter <= 0)
        {
            healthAmount -= damage;
            healthDisplay.fillAmount = healthAmount / 100f;

            if(healthAmount <= 0)
            {
                SceneManager.LoadScene("Death Menu");
            }
            else
            {
                thePlayer.Knockback(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCount = flashLength;
            }
        }
    }

    public void healPlayer(float heal)
    {
        healthAmount += heal;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthDisplay.fillAmount = healthAmount / 100f;
    }
}
