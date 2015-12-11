using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	float respawnTimer = 1f;
	public int numLives = 6;
    public int numberOfMonsters = 0;
    public GameObject enemyPrefab;
	public GameObject enemyPrefab2;
	GameObject EnemyInstance; 
	GameObject EnemyInstance2;
    public float SpawnDistance = 20f;
    private int number;
    private bool spawnMonster = true;

	void Start () {
        //Spawn ();
        number = Random.Range(1, 6);
    }
	void Update () {
        number = Random.Range(1, 6);
        if (EnemyInstance == null)
		{
			respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                Spawn();
            }
        }
        if (numberOfMonsters >= 6)
        {
            spawnMonster = false;
            if (numberOfMonsters <= 5)
            {
                spawnMonster = true;
            }
        }
        // Update is called once per frame
    }

    //void SpawnMidget()
    //{
    //    numLives--;
    //    respawnTimer = 2f;
    //    //enemySpawnRate *= 0.9f;
    //    Vector3 offset = Random.onUnitSphere;
    //    offset.z = 0;
    //    offset = offset.normalized * SpawnDistance;
    //    EnemyInstance = (GameObject)Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
    //}

    //void SpawnBoss()
    //{
    //    numLives--;
    //    respawnTimer = 2f;
    //    //enemySpawnRate *= 0.9f;
    //    Vector3 offset = Random.onUnitSphere;
    //    offset.z = 0;
    //    offset = offset.normalized * SpawnDistance;
    //    EnemyInstance2 = (GameObject)Instantiate(enemyPrefab2, transform.position + offset, Quaternion.identity);
    //}

    void Spawn()
    {
        numLives--;
        //enemySpawnRate *= 0.9f;
        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        offset = offset.normalized * SpawnDistance;
        if (number == 1 || number == 2 || number == 3 && spawnMonster == true)
        {
            EnemyInstance = (GameObject)Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
            respawnTimer = 4f;
            numberOfMonsters++;
        }
        if (number == 4 || number == 5 || number == 6 && spawnMonster == true)
        {
            EnemyInstance2 = (GameObject)Instantiate(enemyPrefab2, transform.position + offset, Quaternion.identity);
            respawnTimer = 8f;
            numberOfMonsters++;
        }
       
    }

    //void OnGUI()
    //{
    //	if (numLives>0||EnemyInstance!=null)
    //		GUI.Label (new Rect (0, 30, 200, 100), "Enemy Lives Left: " + numLives);
    //	else if (numLives<=0&&EnemyInstance2==null)
    //		GUI.Label (new Rect (Screen.width /2 - 50, Screen.height/2-25, 100, 50), "You Win!!!!!! " );
    //}
}

