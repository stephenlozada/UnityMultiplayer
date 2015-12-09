using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

    float currentHealth = 0;
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
      
    }

    void OnTriggerEnter2D()
    {
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            currentHealth -= 33.3333333333f;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
        }
         if (GameObject.FindGameObjectWithTag("Mutant"))
        {
            currentHealth -= 75f;
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
        score += 100;
        
    }
    public void setHealthBar(float myHealth)
    {
        HealthBar.transform.localScale = new Vector3(myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }
	void OnGUI()
	{
		GUI.Label (new Rect (0, 0, 100, 50), "Ammo: " );
	}
}
