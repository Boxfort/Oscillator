using UnityEngine;
using System.Collections;

public class DrawWave : MonoBehaviour {

	public LineRenderer lr;


	public float xOffset = 0;
	public float speed = 0.5f;
	public float amplitude = 1.0f;
	public float frequency = 1.0f;

	private float waveY, waveX;
	private int vertexCount = 50;
	private Vector2[] plotPoints;

	// Use this for initialization
	void Start () 
	{
		lr.SetVertexCount (vertexCount);
		waveY = 0;
		waveX = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		waveY += Time.deltaTime;

		for (int i = 0; i < vertexCount; i++) 
		{
			Vector3 pos = new Vector3((i * frequency) + xOffset, Mathf.Sin(i + Time.time * speed) * amplitude, 0);
			lr.SetPosition(i, pos);
		}
	}
}
