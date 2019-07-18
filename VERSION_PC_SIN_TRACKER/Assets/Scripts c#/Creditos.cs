using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Creditos : MonoBehaviour {
	
	public string nombreArchivo;
	public int speed; 
	private Text texto;
	private string contenidoMensaje;
	
	void Start() {
		TextAsset archivo = Resources.Load(this.nombreArchivo) as TextAsset;
		this.contenidoMensaje = archivo.text;
		this.texto = this.gameObject.GetComponent<Text> ();
		this.texto.text = this.contenidoMensaje;
	}
	
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("MenuPrincipal1");
		}
		this.transform.Translate (Vector3.up * Time.deltaTime * speed);
		//StartCoroutine (waitFor ()); 
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds(40);
		Application.LoadLevel ("MenuPrincipal1");
	}
}