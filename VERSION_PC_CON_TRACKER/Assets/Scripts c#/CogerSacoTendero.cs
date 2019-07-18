using UnityEngine;
using System.Collections;

public class CogerSacoTendero : MonoBehaviour {

	private variablesHUD varHUD;
	private controladorEscena control;

	void Start () {
		this.varHUD = GameObject.Find ("HUD").GetComponent<variablesHUD> ();
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();
	}

	void OnMouseDown() {
		if (Tracker.T () != null)
			Tracker.T ().Click(Input.mousePosition.x, Input.mousePosition.y, this.gameObject.name);

		this.gameObject.SetActive (false);
		this.varHUD.aumentaDinero(75);
		this.varHUD.aumentaCortesia (-20);
		VariablesGenerales.Instance.completarTareaEspecialRobarPosadero ();
		this.control.marcarTareaCompleta (5, true, true);
	}
}