using UnityEngine;
using System.Collections;

public class TutBotonRecargar : MonoBehaviour {
	private GameObject paso1;
	private GameObject paso2;

	void Start (){
		this.paso1 = GameObject.Find ("Paso1");
		this.paso2 = GameObject.Find ("Paso2");
		this.paso1.SetActive (false);
	}

	void OnMouseDown() {
		this.paso2.SetActive (false);
		this.paso1.SetActive (true);
	}
}