using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class MenuScript : MonoBehaviour {

	public AudioSource audioSource;
	public Canvas leaderBoard;
	public Text[] mainButtons;
	public Text[] names;
	public Text[] scores;

	struct Entry
	{
		public string name;
		public int score;
	}

	private List<Entry> entries;

	void Start()
	{
		leaderBoard.enabled = false;

		entries = new List<Entry> ();

		foreach (Text t in names)
			t.text = "";

		foreach (Text t in scores)
			t.text = "";
	}

	public void loadLevel(int level)
	{
		Application.LoadLevel (level);
	}

	public void playSound()
	{
		audioSource.Play ();
	}

	public void showLeaderboard()
	{
		foreach (Text t in mainButtons)
			t.enabled = false;

		leaderBoard.enabled = true;

		StreamReader reader = new StreamReader(File.OpenRead("scores.txt"));

		while (!reader.EndOfStream)
		{
			var line = reader.ReadLine();
			var values = line.Split(',');

			Entry score = new Entry();
			score.name = values[0];
			score.score = Convert.ToInt32(values[1]);

			entries.Add(score);
		}

		var temp = entries.OrderByDescending(x => x.score);

		List<Entry> list2 = new List<Entry> (temp);

		for (int i = 0; i < 5; i++) 
		{
			string name = list2[i].name;
			string score = list2[i].score.ToString();

			names[i].text = name;
			scores[i].text = score;
		}
	}
	
	public void hideLeaderboard()
	{
		foreach (Text t in mainButtons)
			t.enabled = true;

		leaderBoard.enabled = false;
		entries.Clear ();
	}

	public void quit()
	{
		Application.Quit ();
	}
}
