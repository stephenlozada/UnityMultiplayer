using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagedMutant : MonoBehaviour {
    float currentHealth = 0;
    float maxHealth = 100;
    public Text ScoreText;
    public Text Statustext;
    float calculatedHealth;
    public GameObject HealthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D()
    {
        if (GameObject.FindGameObjectWithTag("Bullet")) //&& !GameObject.FindGameObjectWithTag("Player"))
        {
            currentHealth -= 2.5f;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
        }
    }
    void Update()
    {
        if (currentHealth <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
        ScoreHandler.score += 1000;   
    }
    public void setHealthBar(float myHealth)
    {
        HealthBar.transform.localScale = new Vector3(myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }

}
