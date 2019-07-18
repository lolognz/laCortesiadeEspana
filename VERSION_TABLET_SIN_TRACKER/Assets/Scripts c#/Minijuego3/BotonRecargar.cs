using UnityEngine;
using System.Collections;

public class BotonRecargar : MonoBehaviour {
	public Sprite botonPulsado; // Drag your first sprite here
	public Sprite botonDespulsado; // Drag your second sprite here
	private Animator pistola;
	public bool activo;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		this.audio = this.gameObject.GetComponent<AudioSource> ();
		this.activo = false;
		this.pistola = GameObject.Find ("Pistola").GetComponent<Animator> ();
	}

	void OnMouseUp() {
		if (activo) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = botonDespulsado;
			this.pistola.SetBool ("recargar", false);
			if (PistolaDuelo.getBalas () < PistolaDuelo.PulsacionesNecesarias)
				PistolaDuelo.SumaBala ();
		}
	}

	void OnMouseDown() {
		if (activo) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = botonPulsado;
			this.pistola.SetBool ("recargar", true);
			this.audio.Stop();
			this.audio.Play();
		}
	}
}
