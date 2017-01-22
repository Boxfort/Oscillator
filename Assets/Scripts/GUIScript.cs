using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public GameObject dial1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		dial1.transform.position = new Vector2 (Screen.width - 50, Screen.height - 50);
		dial1.transform.localScale = new Vector2 (Screen.width / 500, Screen.width / 500);
	}
}
