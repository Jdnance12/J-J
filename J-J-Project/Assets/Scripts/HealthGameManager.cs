using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class HealthGameManager : MonoBehaviour
{

    public Image strike1;
    public Image strike2;
    public Image strike3;

    public float maxHealth = 1f;
    private float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        
            currentHealth = 0;

            UpdateHealthBar();

            if (currentHealth == 0)
            {
                GameOver();
            }
        
    }


    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
       if (currentHealth >= 3)
        {
            strike1.enabled = true;
            strike2.enabled = true;
            strike3.enabled = true;
            strike1.color = Color.white;
            strike2.color = Color.white;
            strike3.color = Color.white;
        } 
        else if (currentHealth >= 2) 
        {
            strike1.enabled = true;
            strike2.enabled = true;
            strike3.enabled = false;
            strike1.color = Color.yellow;
            strike2.color = Color.yellow;
        }
       else if (currentHealth >= 1)
        {
            strike1.enabled = true;
            strike2.enabled = false;
            strike3.enabled = false;
            strike1.color = Color.red;
        } 
        else
        {
            strike1.enabled = false;
            strike2.enabled = false;
            strike3.enabled = false;
        }

       
    }
    void GameOver()
    {

        Debug.Log("Game Over! Player has no strikes left.");
    }
}
