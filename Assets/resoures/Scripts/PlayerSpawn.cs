using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTimer = 1f;
	public int numLives = 4;

	// Use this for initialization
	void Start () {
        Spawn();

	}
	
	// Update is called once per frame
	void Update () {
        if(playerInstance == null)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer<=0 )
            Spawn();
        }
	
	}
    void Spawn()
    {
		numLives--;
		respawnTimer = 1f;
		if(numLives>=0)
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
	void OnGUI()
	{
		if (numLives>0||playerInstance!=null)
		GUI.Label (new Rect (0, 15, 100, 50), "Lives Left: " + numLives);
		else 
			GUI.Label (new Rect (Screen.width /2 - 50, Screen.height/2-25, 100, 50), "GameOVer!!!!!! " );
	}
}
