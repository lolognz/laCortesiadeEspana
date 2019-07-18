using UnityEngine;
using System.Collections;

public class TutBotonDisparar : MonoBehaviour {


	void OnMouseDown() {
		GameObject.Find ("Paso1").SetActive (false);
		GameObject.Find ("fondoTutorial").SetActive (false);
		GameObject.Find ("Textos").SetActive (false);
		GameObject.Find ("BotonDisparar").GetComponent<BotonDisparo> ().activo = true;
		GameObject.Find ("BotonCarga").GetComponent<BotonRecargar> ().activo = true;
		GameObject.Find ("ControladorEscena").GetComponent<controladorMinijuego3> ().comenzarCuantaAtras ();
		GameObject.Find ("Marcelo").GetComponent<Animator> ().SetBool ("empezar", true);
	}
}