using UnityEngine;
using System.Collections;

public class ControladorPatrocinadores : MonoBehaviour {

	void Start () {
		StartCoroutine (espera ());
	}

	IEnumerator espera(){
		yield return new WaitForSeconds(2);
		GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("MenuPrincipal1");
	}
}