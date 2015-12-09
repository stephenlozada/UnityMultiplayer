using UnityEngine;
using System.Collections;

public class AmmoSpawner : MonoBehaviour {
	public GameObject AmmoPrefab;
	GameObject AmmoInstance;
	float respawnTimer = 1f;
	public float SpawnDistance = 10f;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		Spawn();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(AmmoInstance == null)
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

		AmmoInstance = (GameObject)Instantiate(AmmoPrefab, transform.position + offset, Quaternion.identity);
	}
}
