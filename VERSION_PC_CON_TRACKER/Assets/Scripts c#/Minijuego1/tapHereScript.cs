using UnityEngine;
using System.Collections;

public class tapHereScript : MonoBehaviour {

	void OnMouseDown() {
		GameObject.Find ("ControladorEscena").GetComponent<controladorMinijuego1> ().desactivarTutorial ();
	}
}