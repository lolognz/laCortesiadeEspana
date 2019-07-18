using UnityEngine;
using System.Collections;

public class AccionAves : MonoBehaviour {

	private AudioSource audio;
	private Animator anim;

	private bool ratonEncontrado = false;
	
	void Start () {
		this.anim = this.GetComponent<Animator> ();
		this.audio = this.gameObject.GetComponent<AudioSource> ();
	}

	void OnMouseDown() {
		if (this.gameObject.tag == "Raton" && !this.ratonEncontrado) {
			this.ratonEncontrado = true;
			VariablesGenerales.Instance.ratonEncontrado ();
		}
			
		this.anim.Play ("Moviendo");
		this.audio.Play ();
	}	
}