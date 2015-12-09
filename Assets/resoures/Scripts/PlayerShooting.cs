using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
    public float AmmoMax;
    public float ammoCount;
    public Text BulletText;
    public Text StatusUpdate;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    public GameObject bulletPrefab;
    public AudioClip[] ShootingSounds;
    public Vector3 bulletOffset = new Vector3(0f, 0.5f, 0f);
    // Update is called once per frame
    void Start()
    {
        AmmoMax = 10;
        ammoCount = AmmoMax;
    }
    void Update () {
	cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0 && ammoCount > 0 )
        {
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            PlaySound(0);
            ammoCount--;
        }
        if (Input.GetButton("Fire1") && ammoCount <= 0)
            PlaySound(1);
        
	}
    void OnGUI()
    {
		GUI.Label (new Rect (Screen.width-150, Screen.height-25, 100, 50), "Ammo: " + ammoCount.ToString() + " / " + AmmoMax.ToString());
        
       // if (Input.GetButton("Fire1") && ammoCount <= 0)
          //  StatusUpdate.text = "Find some Ammo";
       

    }
    void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = ShootingSounds[clip];
        GetComponent<AudioSource>().Play();
    }
}
