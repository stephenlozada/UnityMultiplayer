using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

    public static float score = 0;
    public static float ammo = 10;
    public static float ammoMax = 10;
    public static float lives = 3;
    private Text guiScore;
    private Text guiAmmo;
    private Text guiLives;

	// Use this for initialization
	void Start () {
        guiScore = GameObject.Find("Score").GetComponent<Text>();
        guiScore.text = "Score: ";
        guiAmmo = GameObject.Find("Ammo").GetComponent<Text>();
        guiAmmo.text = "Ammo: ";
        guiLives = GameObject.Find("Lives").GetComponent<Text>();
        guiLives.text = "Lives Left: ";

	}
	
	// Update is called once per frame
	void Update () {
        guiScore.text = "Score: " + ScoreHandler.score;
        guiAmmo.text = "Ammo: " + ScoreHandler.ammo + "/10";
        guiLives.text = "Lives Left: " + ScoreHandler.lives;
	}
}
