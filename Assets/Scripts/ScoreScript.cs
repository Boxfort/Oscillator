using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private int score;
	public GameObject scoreObject;
	public Text scoreText;

	// Use this for initialization
	void Start () 
	{
		score = 0;
		scoreText = scoreObject.GetComponent<Text> ();
	}

	public void increaseScore()
	{
		score++;
		scoreText.text = score.ToString();
	}

}
