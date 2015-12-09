using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    private Text scoreText;

    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Final Score: " + ScoreHandler.score;
	}
}
