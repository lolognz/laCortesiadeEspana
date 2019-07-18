using UnityEngine;
using System.Collections;

public class BotonDisparo : MonoBehaviour {
	public Sprite botonPulsado; // Drag your first sprite here
	public Sprite botonDespulsado; // Drag your second sprite here
	private Animator pistola;
	private Animator marcelo;
	public bool activo;

	private AudioSource audio;
	private AudioSource audioQueja;

	private GameObject contenedorRecarga;
	private GameObject botonRecarga;
	
	void Start () {
		this.activo = false;
		this.audio = GameObject.Find("Sonido disparo").GetComponent<AudioSource> ();
		this.pistola = GameObject.Find ("Pistola").GetComponent<Animator> ();
		this.marcelo = GameObject.Find ("Marcelo").GetComponent<Animator> ();
		this.botonRecarga = GameObject.Find ("ContenedorBotonRecarga");
		this.contenedorRecarga = GameObject.Find ("ContenedorRecarga");
		this.audioQueja = GameObject.Find("Sonido queja").GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if (activo) {
			if (PistolaDuelo.getBalas () >= PistolaDuelo.PulsacionesNecesarias)
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = botonDespulsado;
			else
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = botonPulsado;
		}
	}

	void OnMouseUp() {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = botonDespulsado;
		this.pistola.SetBool ("disparar", false);
		if ( PistolaDuelo.getBalas () >= PistolaDuelo.PulsacionesNecesarias) {
			PistolaDuelo.resetBalas ();
		}
	}

	void OnMouseDown() {
		if (activo) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = botonPulsado;
			if (PistolaDuelo.getBalas () >= PistolaDuelo.PulsacionesNecesarias) {
				GameObject.Find("ControladorEscena").GetComponent<controladorMinijuego3>().setFinalizado();
				this.pistola.SetBool ("disparar", true);
				this.audio.Play();
				this.marcelo.enabled = false;
				this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				this.botonRecarga.SetActive(false);
				this.contenedorRecarga.SetActive(false);
				StartCoroutine (waitFor ());
			}
		}
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds(0.4f);
		this.audioQueja.Play ();
		GameObject.Find("ControladorEscena").GetComponent<controladorMinijuego3>().activarResultadoVictoria ();
	}
}