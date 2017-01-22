using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("Wait");
	}
	
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		
		Application.LoadLevel(1);
	}
}
