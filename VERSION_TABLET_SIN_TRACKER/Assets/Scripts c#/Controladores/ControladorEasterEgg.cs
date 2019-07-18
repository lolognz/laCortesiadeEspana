using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorEasterEgg : MonoBehaviour {

	private InputField nombreRaton;

	void Start () {
		this.nombreRaton = GameObject.Find ("InputField").GetComponent<InputField> ();
		this.nombreRaton.text = VariablesGenerales.Instance.getNombreRaton ();
	}

	public void volverMenu() {
		VariablesGenerales.Instance.darNombreRaton (this.nombreRaton.text);
		GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("MenuPrincipal2");
	}
}