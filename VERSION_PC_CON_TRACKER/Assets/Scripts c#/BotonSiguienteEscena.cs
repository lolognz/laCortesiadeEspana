using UnityEngine;
using System.Collections;

public class BotonSiguienteEscena : MonoBehaviour {
		
	void Start () {
		this.gameObject.SetActive (false);
	}
	
	public void activarBotonSiguienteEscena() {
		this.gameObject.SetActive (true);
	}
}