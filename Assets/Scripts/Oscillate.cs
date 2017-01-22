using UnityEngine;
using System.Collections;

public class Oscillate : MonoBehaviour 
{
	public float xOffset = 0;
	public float speed = 10.0f;
	public float amplitude = 1.0f;
	public float frequency = 1.0f;
	public GameObject bullet;

	private BulletType type;
	private LineRenderer lr;
	private AudioSource audio;
	private float waveX, waveY, waveY2;
	private int vertexCount = 1000;

	float a, b, timer, timer2;

	bool canshoot;

	// Use this for initialization
	void Start () 
	{
		audio = transform.GetComponent<AudioSource> ();
		lr = transform.GetComponent<LineRenderer> ();
		lr.SetVertexCount (vertexCount);
		lr.SetWidth (0.2f, 0.2f);
		frequency = 10.0f;
		type = BulletType.red;
		amplitude = 5.0f;
		waveX = 0.0f;
		waveY = 0.0f;
		waveY2 = 0.0f;
		speed = 50.0f;
		a = 2.0f;
		timer = Time.time;
		canshoot = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandleInput ();
		MoveSine ();
		DrawWave ();
	}

	void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			amplitude += 5;
		}

		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			amplitude -= 5;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			frequency += 5;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			frequency -= 5;
		}

		frequency = Mathf.Clamp (frequency, 10, 25);
		amplitude = Mathf.Clamp(amplitude, 5, 20);

		switch ((int)frequency) 
		{
		case 10:
			audio.pitch = 1.3f;
			lr.SetColors(Color.red, Color.red);
			type = BulletType.red;
			break;
		case 15:
			audio.pitch = 1.2f;
			lr.SetColors(Color.yellow, Color.yellow);
			type = BulletType.yellow;
			break;
		case 20:
			audio.pitch = 1.1f;
			lr.SetColors(Color.green, Color.green);
			type = BulletType.green;
			break;
		case 25:
			audio.pitch = 1.0f;
			lr.SetColors(Color.blue, Color.blue);
			type = BulletType.blue;
			break;
		}
	}

	void shoot()
	{
		GameObject instance = (GameObject) Instantiate (bullet, transform.position, Quaternion.identity);
		instance.gameObject.GetComponent<PlayerBullet> ().setType (type);
		Destroy (instance, 9.0f);
		//Instantiate (bullet, transform.position, Quaternion.identity);
	}

	void setAmplitude(float amp)
	{
		amplitude = amp;
	}

	void setFrequency(float freq)
	{
		frequency = freq;
	}
	
	void MoveSine()
	{

		b = waveX;
		timer2 = Time.time;

		if ( Mathf.Sign(a) != Mathf.Sign (b) ) 
		{
			//RELOAD SHOT
			canshoot = true;

			timer = timer2;
			a = b;
		}

		//Move ball in sine wave
		waveY += (frequency * Time.deltaTime);
		
		waveX = Mathf.Sin (Time.time * speed);

		//Debug.Log (waveX);

		if ((waveX > 0.95f || waveX < -0.95f) && canshoot) 
		{
			Debug.Log ("shoot");
			canshoot = false;
			shoot ();
		}
		
		transform.position = new Vector2 (0, waveX * amplitude);
	}

	void MoveSquare()
	{
		//Move ball in sine wave
		waveY += (frequency * Time.deltaTime);
		
		waveX = Mathf.Sin (Time.time * speed) * amplitude;

		waveX = (waveX >= 0) ? amplitude : -amplitude;
		
		transform.position = new Vector2 (0, waveX);
	}

	void DrawWave()
	{
		speed = 2.5f * (1 / (frequency) * 15);

		waveY += Time.deltaTime;
		
		for (int i = 0; i < vertexCount; i++) 
		{
			var yval = Mathf.Sin(i + Time.time * speed) * amplitude;
			//yval = (yval >= 0) ? amplitude : -amplitude;

			Vector3 pos = new Vector3(((i * frequency) / 10) + xOffset, yval , 0);
			lr.SetPosition(i, pos);

			//Hide line outside of screen, BAD MAGIC NUMBER
			if( pos.x > 28 )
			{
				lr.SetPosition(i, new Vector3(28, 0, 0));
			}
		}
	}
}
