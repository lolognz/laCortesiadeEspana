using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	
	private Animator claudio;
	
	public GameObject[] objetos;
	public float tiempoMin = 1f;
	public float tiempoMax = 2f;
	public string direccion;
	public bool activo;
	private bool hecho;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		this.activo = false;
		this.hecho = false;
		this.claudio = GameObject.Find ("Claudio").GetComponent<Animator> ();
		this.audio = GameObject.Find ("SonidoLanzar").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Ponemos a cero todos los estados de claudio.
		this.claudio.SetBool ("DR", false);
		this.claudio.SetBool ("DL", false);
		this.claudio.SetBool ("UR", false);
		this.claudio.SetBool ("UL", false);
		
		if (activo && !hecho) {
			this.hecho = true;
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
		}
	}
	
	public void Generar(){
		if (this.activo) {
			this.claudio.SetBool (direccion, true);
			this.audio.Play ();
			this.subirVelocidad();
			GameObject obj = objetos[Random.Range (0, objetos.Length)];
			Instantiate (obj, this.transform.position, Quaternion.identity);
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
		}
	}
	
	private void subirVelocidad() {
		if (tiempoMin >= 1f) {
			tiempoMin -= 1f;
		}
		
		if (tiempoMax >= 2f) {
			tiempoMax -= 1f;
		}
		
		/*Debug.Log ("T.Minimo: " + tiempoMin);
		Debug.Log ("T.Maximo: " + tiempoMax);*/
	}
}