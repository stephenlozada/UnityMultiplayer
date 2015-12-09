using UnityEngine;
using System.Collections;

public class HealthSpawner : MonoBehaviour {
	public GameObject HealthPrefab;
	GameObject HealthInstance;
	float respawnTimer = 1f;
	public float SpawnDistance = 10f;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		Spawn();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(HealthInstance == null)
		{
			respawnTimer -= Time.deltaTime;
			if(respawnTimer<=0 )
				Spawn();
		}
		
	}
	void Spawn()
	{
		
		respawnTimer = 3f;
		Vector3 offset = Random.onUnitSphere;
		offset.z = 0;
		offset = offset.normalized * SpawnDistance;
		
		HealthInstance = (GameObject)Instantiate(HealthPrefab, transform.position + offset, Quaternion.identity);
	}
}
