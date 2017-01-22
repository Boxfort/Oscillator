using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public BulletType type;
	public Material[] materials;
	
	public TrailRenderer tr;
	public SpriteRenderer sr;
	public Light light;

	private float speed = 3.25f;
	
	// Use this for initialization
	void Start () 
	{
		tr = transform.GetComponent<TrailRenderer> ();
		sr = transform.GetComponent<SpriteRenderer> ();
		light = GetComponent<Light> ();
		materials = new Material[4];
	}
	
	public void setType(BulletType bullet)
	{
		type = bullet;
		
		switch (bullet) 
		{
		case BulletType.red:
			tr.material = materials[0];
			sr.material = materials[0];
			light.color = Color.red;
			break;
		case BulletType.yellow:
			tr.material = materials[1];
			sr.material = materials[1];
			light.color = Color.yellow;
			break;
		case BulletType.green:
			tr.material = materials[2];
			sr.material = materials[2];
			light.color = Color.green;
			break;
		case BulletType.blue:
			tr.material = materials[3];
			sr.material = materials[3];
			light.color = Color.blue;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime);

		if (transform.position.x < 1)
			speed = 10.0f;
	}
}
