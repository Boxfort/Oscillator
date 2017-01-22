using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float speed = 3.75f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector2 (-speed * Time.deltaTime, 0));
	}
}
