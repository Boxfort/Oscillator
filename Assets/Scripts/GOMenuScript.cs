using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GOMenuScript : MonoBehaviour {

	public InputField name;
	public Text score;

	private string filename;
		
	// Use this for initialization
	void Start () 
	{
		filename = "scores.txt";

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void QuitGame()
	{
		Application.LoadLevel (1);
	}

	public void SubmitScore()
	{
		if (name.text.Length != 3) 
			return;

		WriteScoreToFile ();
		Application.LoadLevel (1);
	}

	private void WriteScoreToFile()
	{
		System.IO.File.AppendAllText(filename, name.text + "," + score.text + Environment.NewLine);
	}
}
