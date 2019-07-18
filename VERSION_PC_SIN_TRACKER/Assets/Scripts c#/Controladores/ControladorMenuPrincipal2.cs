using UnityEngine;
using System.Collections;

public class ControladorMenuPrincipal2 : MonoBehaviour {

	private GameObject easterEggRaton;

	void Start () {
		this.easterEggRaton = GameObject.Find("EasterEggRaton");

		VariablesGenerales.Instance.setFinal (""); //Para que los creditos se carguen bien.

		if (!VariablesGenerales.Instance.getEasterEggRaton ())
			this.easterEggRaton.SetActive (false);
	}
}