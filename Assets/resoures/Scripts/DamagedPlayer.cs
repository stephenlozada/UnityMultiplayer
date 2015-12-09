using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagedPlayer : MonoBehaviour {
    float  currentHealth = 0;
    float maxHealth = 100;
    public Text Statustext;
    float calculatedHealth;
    public GameObject HealthBar;
    public GameObject HealthPack;
    public GameObject AmmoPack;
    private ScoreHandler info;
    public AudioClip[] PickupSounds;
    public GameObject AmmoParticle;
    public GameObject HealthParticle;
    private int number;

    void Start()
    {
        currentHealth = maxHealth;
        info = GetComponent<ScoreHandler>();
        number = Random.Range(1, 9);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            currentHealth -= 34f;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
        }
        else if (col.gameObject.tag == "Mutant")
        {
            currentHealth -= 50f;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
        }
        else if (col.gameObject.tag == "Teleporter")
        {

            if (number == 1 || number == 2 || number == 3)
            {
                Application.LoadLevel("Vr");
                ScoreHandler.lives++;
            }
            if (number == 4 || number == 5 || number == 6)
            {
                Application.LoadLevel("Vr2");
                ScoreHandler.lives++;
            }
            if (number == 7 || number == 8 || number == 9)
            {
                Application.LoadLevel("Vr3");
                ScoreHandler.lives++;
            }           
        }
        else if (col.gameObject.tag == "HealthPack")
        {
            if (currentHealth < 100)
            {
                currentHealth += 50;
                if (currentHealth > 100)
                {
                    float leftOver = currentHealth - maxHealth;
                    currentHealth = currentHealth - leftOver;
                }
                calculatedHealth = currentHealth / maxHealth;
                setHealthBar(calculatedHealth);
                PlaySound(0);
                Destroy(HealthPack);
                Instantiate(HealthParticle,transform.position + new Vector3(0, 0, -2.7f), transform.rotation);
            }
        }
        else if (col.gameObject.tag == "Ammunation")
        {
            if (ScoreHandler.ammo <= 10)
            {
                ScoreHandler.ammo += 10;
                Instantiate(AmmoParticle, transform.position + new Vector3(0, 0, -2.7f), transform.rotation);
                PlaySound(1);
            }
            if (ScoreHandler.ammo >= 10)
            {
                float leftOver = ScoreHandler.ammo - ScoreHandler.ammoMax;
                ScoreHandler.ammo = ScoreHandler.ammo - leftOver;
            }     
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
    }
    public void setHealthBar(float myHealth)
    {
        HealthBar.transform.localScale = new Vector3 (myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }
    void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = PickupSounds[clip];
        GetComponent<AudioSource>().Play();
    }
}
