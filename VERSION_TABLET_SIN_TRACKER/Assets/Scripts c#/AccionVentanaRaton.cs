using UnityEngine;
using System.Collections;

public class AccionVentanaRaton : MonoBehaviour {
	
	private AudioSource audio;
	private Animator anim;
	
	void Start () {
		this.anim = this.GetComponent<Animator> ();
		this.audio = this.gameObject.GetComponent<AudioSource> ();
	}
	
	void OnMouseDown() {
		this.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		VariablesGenerales.Instance.ratonEncontrado ();

		this.anim.Play ("Moviendo");
		this.audio.Play ();
	}	
}