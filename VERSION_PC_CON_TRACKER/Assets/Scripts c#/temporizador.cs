using UnityEngine;
using System.Collections;

public class temporizador : MonoBehaviour {
	public float segundos = 4.6f;
	public string scene;

	void FixedUpdate () {
		StartCoroutine (waitFor ()); 
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds(segundos);
		Application.LoadLevel (scene);
	}
}