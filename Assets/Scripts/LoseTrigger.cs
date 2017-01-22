using UnityEngine;
using System.Collections;

public class LoseTrigger : MonoBehaviour 
{
	public Canvas gameoverGui;
	public GameObject player;
	public GameObject spawner;

	void Start()
	{
		gameoverGui.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "enemyBullet") 
		{
			gameoverGui.enabled = true;
			Destroy(player);
			Destroy(spawner);

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("enemyBullet"))
			{
				Destroy (g);
			}
		}
		
	}

}
