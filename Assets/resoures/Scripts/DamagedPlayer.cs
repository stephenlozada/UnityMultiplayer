using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagedPlayer : MonoBehaviour {
    float  currentHealth = 0;
    float maxHealth = 100;
    int score;
    public Text ScoreText;
    public Text Statustext;
    float calculatedHealth;
    public GameObject HealthBar;
    public GameObject HealthPack;
    public GameObject AmmoPack;
    private PlayerShooting info;
    public AudioClip[] PickupSounds;
    public GameObject AmmoParticle;
    public GameObject HealthParticle;
    void Start()
    {
        currentHealth = maxHealth;
        score = 0;
        setCountText();
        info = GetComponent<PlayerShooting>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag =="Enemy")
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
            if (info.ammoCount < 10)
            {
                info.ammoCount += 10;
                PlaySound(1);
                Destroy(AmmoPack);
                Instantiate(AmmoParticle, transform.position + new Vector3(0, 0, -2.7f), transform.rotation);
                if (info.ammoCount > 10)
                {
                    float leftOver = info.ammoCount - info.AmmoMax;
                    info.ammoCount = info.ammoCount - leftOver;
                }
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
    void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = PickupSounds[clip];
        GetComponent<AudioSource>().Play();
    }
}
