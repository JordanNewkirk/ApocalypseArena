using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCount;
    public float flashLength = 0.1f;

    public TextMeshProUGUI healthDisplay;

    private void Start()
    {
        currentHealth = maxHealth;
        SetHealthText();
    }


    // Start is called before the first frame update

    void SetHealthText()
    {
        healthDisplay.text = "Health: " + currentHealth.ToString();
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

    public void hurtPlayer(int damage, Vector3 direction)
    {
        if(invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            SetHealthText();

            if(currentHealth <= 0)
            {
                //die
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

    public void healPlayer(int heal)
    {
        currentHealth += heal;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
