using UnityEngine;
using System.Collections;

public class MenuPausa : MonoBehaviour {

	private float posicionInicioX;

	void Start() {
		this.posicionInicioX = transform.position.x;
	}

	void Update() {
		transform.position = new Vector3 (Camera.main.transform.position.x - this.posicionInicioX - 7, transform.position.y, transform.position.z);
	} 

	void OnMouseDown() {
		Application.LoadLevel ("MenuPrincipal");
		if (GameObject.Find ("HUD") != null)
			Destroy(GameObject.Find ("HUD"));
	}
}
