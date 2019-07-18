using UnityEngine;
using System.Collections;

public class EncontrarZorrilla : MonoBehaviour {

	void OnMouseDown() {
		GameObject.Find ("ControladorEscena").GetComponent<controladorMinijuego2> ().terminarJuego ();
	}
}