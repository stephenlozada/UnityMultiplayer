using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	float respawnTimer = 1f;
	public int numLives = 6;

    public GameObject enemyPrefab;
	public GameObject enemyPrefab2;
	GameObject EnemyInstance; 
	GameObject EnemyInstance2;
    public float SpawnDistance = 20f;

	void Start () {

		Spawn ();
	}
	void Update () {
		if(EnemyInstance == null)
		{
			respawnTimer -= Time.deltaTime;
			if(respawnTimer<=0 )
				Spawn();
		}
	// Update is called once per frame

	}
	void Spawn()
	{
		numLives--;
		respawnTimer = 1f;
		//enemySpawnRate *= 0.9f;
		Vector3 offset = Random.onUnitSphere;
		offset.z = 0;
		offset = offset.normalized * SpawnDistance;
		if (numLives >= 1)
			EnemyInstance = (GameObject)Instantiate (enemyPrefab, transform.position + offset, Quaternion.identity);
		else if(numLives>=0) {

			EnemyInstance2 = (GameObject)Instantiate (enemyPrefab2, transform.position + offset, Quaternion.identity);

		}
	}
	void OnGUI()
	{
		if (numLives>0||EnemyInstance!=null)
			GUI.Label (new Rect (0, 30, 200, 100), "Enemy Lives Left: " + numLives);
		else if (numLives<=0&&EnemyInstance2==null)
			GUI.Label (new Rect (Screen.width /2 - 50, Screen.height/2-25, 100, 50), "You Win!!!!!! " );
	}
}

