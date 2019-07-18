using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EfectoParpadeo : MonoBehaviour {
	
	private Image botonSiguienteEscena;
	
	//private bool modificar = true;
	private bool subirTrasparencia = true;
	private byte trasparencia = 255;
	
	void Start () {
		this.botonSiguienteEscena = this.gameObject.GetComponent<Image> ();
		//StartCoroutine (DuracionParpadeo ());
	}
	
	void FixedUpdate() {
		//if (this.modificar) {
		if (this.trasparencia >= 255)
			this.subirTrasparencia = false;
		
		if (this.trasparencia <= 0)
			this.subirTrasparencia = true;
		
		if (this.subirTrasparencia)
			this.trasparencia+=3;
		else
			this.trasparencia-=3;
		
		this.botonSiguienteEscena.color = new Color32(255,255,255,this.trasparencia);
		//}
	}
	
	IEnumerator DuracionParpadeo() {
		yield return new WaitForSeconds (2f);
		//this.modificar = false;
		this.botonSiguienteEscena.color = new Color32(255,255,255,255);
	}
}