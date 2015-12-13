using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Damaged : NetworkBehaviour {
    float  currentHealth = 0;
    float maxHealth = 100;
    public Text Statustext;
    float calculatedHealth;
    public GameObject HealthBar;
    int shotyDmg = 100;
    int revolverDmg = 50;
    int rifleDmg = 20;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet" && PlayerShooting.revolverEnable)
        {
            currentHealth -= 50;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
            string uidentity = transform.name;
            CmdTellServerWhoWasShot(uidentity,revolverDmg);
        }
        if (col.gameObject.tag == "Bullet" && PlayerShooting.rifleEnable)
        {
            currentHealth -= 20;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
            string uidentity = transform.name;
            CmdTellServerWhoWasShot(uidentity, rifleDmg);
        }
        if (col.gameObject.tag == "Bullet" && PlayerShooting.ShottyEnable)
        {
            currentHealth -= 100;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
            string uidentity = transform.name;
            CmdTellServerWhoWasShot(uidentity, shotyDmg);
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
        ScoreHandler.score += 100;
    }
    public void setHealthBar(float myHealth)
    {
        HealthBar.transform.localScale = new Vector3 (myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }

    [Command]
    void CmdTellServerWhoWasShot(string uniqueID, int dmg)
    {
        GameObject go = GameObject.Find(uniqueID);
        go.GetComponent<PlayerHealth>().DeductHealth(dmg);
    }
 

}
