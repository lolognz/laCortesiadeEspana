using UnityEngine;
using System.Collections;

public class CargarEscena : MonoBehaviour {
	
	public void cargarEscena(string escena) {
		Application.LoadLevel (escena);
	}
	
	public void cargarEscenaMenuInicio() {
		if (VariableJuegoPasado.Instance.getJuegoPasado ()) {
			if (GameObject.Find ("Loader") != null)
				GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("MenuPrincipal2");
			else
				Application.LoadLevel ("MenuPrincipal2");
		}

		else {
			if (GameObject.Find ("Loader") != null)
				GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("MenuPrincipal1");
			else
				Application.LoadLevel ("MenuPrincipal1");
		}
	}
}