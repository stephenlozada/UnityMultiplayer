using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
           // GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
            GetComponent<Playermovement>().enabled = true;
            GetComponent<PlayerShooting>().enabled = true;
            GetComponent<DamagedPlayer>().enabled = true;
            
                
        } 
	}
	
	
}
