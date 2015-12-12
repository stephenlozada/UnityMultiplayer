using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MonsterID : NetworkBehaviour {

    [SyncVar]
    public string monsterId;

    private Transform myTransform;
	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        SetIdentity();
	}
    void SetIdentity()
    {
        if (myTransform.name == "" || myTransform.name == "Enemy(Clone)" || myTransform.name == "Mutant(Clone)")
        {
            myTransform.name = monsterId;
        }
    }
}
