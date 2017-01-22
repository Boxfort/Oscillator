using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public GameObject enemyBullet;
	private int previous;

	private float[] spawnLocations;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Spawn", 0.0f, 4.0f);
		Debug.Log ("Hello");
		previous = -1;

		spawnLocations = new float[]{ 19f, 14f, 9.5f, 4.6f, -4.6f, -9.5f, -14f, -19f };
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void Spawn()
	{
		int rand;

		rand = Random.Range (0, (int)BulletType.NumberOfTypes);

		previous = rand;

		GameObject instance = (GameObject)Instantiate (enemyBullet, new Vector2(transform.position.x, spawnLocations[rand]), Quaternion.identity);
		instance.gameObject.GetComponent<EnemyBullet> ().setType ((BulletType)rand);
	}
}
