using UnityEngine;
using System.Collections;

public class ControladorMenuPrincipal2 : MonoBehaviour {

	private GameObject easterEggRaton;

	void Start () {
		this.easterEggRaton = GameObject.Find("EasterEggRaton");

		if (Tracker.T () != null) {
			Tracker.T ().Screen ("MenuPrincipal2");
			Tracker.T ().RequestFlush();
		}

		VariablesGenerales.Instance.setFinal (""); //Para que los creditos se carguen bien.

		if (!VariablesGenerales.Instance.getEasterEggRaton ())
			this.easterEggRaton.SetActive (false);
	}
}