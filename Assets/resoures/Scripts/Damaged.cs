﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Damaged : MonoBehaviour {
    float  currentHealth = 0;
    float maxHealth = 100;
    int score;
    public Text ScoreText;
    public Text Statustext;
    float calculatedHealth;
    public GameObject HealthBar;

    void Start()
    {
        currentHealth = maxHealth;
        score = 0;
        setCountText();
    }

    void OnTriggerEnter2D()
    {
        if (GameObject.FindGameObjectWithTag("Bullet")) //&& !GameObject.FindGameObjectWithTag("Player"))
        {
            currentHealth -= 25;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
        }
    }
    void Update()
    {
        if (currentHealth <= 0.5f)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
        score += 100;
        setCountText();
    }
    public void setHealthBar(float myHealth)
    {
        HealthBar.transform.localScale = new Vector3 (myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }
    void setCountText()
    {
        ScoreText.text = "Score: " + score.ToString();
        if (score >= 100)
        Statustext.text = "YOU WIN!!!!!!!!!!!!!";
    }

}
