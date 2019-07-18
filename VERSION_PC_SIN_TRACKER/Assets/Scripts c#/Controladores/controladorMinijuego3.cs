using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controladorMinijuego3 : MonoBehaviour {

	private GameObject resultado;
	private Text mensajeTitulo;
	private Text mensajeExplicacion;
	private GameObject botonContinuar;
	private GameObject botonTerminar;

	private Animator marcelo;
	private GameObject contenedorRecarga;
	private GameObject botonRecarga;
	private GameObject botonDisparo;

	private AudioSource audioFondo;
	private AudioSource audioDisparo;
	private AudioSource audioQueja;

	public int segundos = 10;
	private bool finalizado = false; // Avisa de si el juego ha terminado (bien o mal)

	void Start () {
		VariablesGenerales.Instance.completarTareaEspecialBatirseDuelo ();
		this.marcelo = GameObject.Find ("Marcelo").GetComponent<Animator> ();
		this.botonRecarga = GameObject.Find ("ContenedorBotonRecarga");
		this.contenedorRecarga = GameObject.Find ("ContenedorRecarga");
		this.botonDisparo = GameObject.Find ("BotonDisparar");

		this.resultado = GameObject.Find("Resultado");
		this.mensajeTitulo = GameObject.Find ("MensajeTitulo").GetComponent<Text> ();
		this.mensajeExplicacion = GameObject.Find ("MensajeExplicacion").GetComponent<Text> ();
		this.botonContinuar = GameObject.Find ("BotonContinuar");
		this.botonTerminar = GameObject.Find ("BotonTerminar");

		this.audioFondo = GameObject.Find ("Sonido fondo").GetComponent<AudioSource> ();
		this.audioDisparo = GameObject.Find("Sonido disparo").GetComponent<AudioSource> ();
		this.audioQueja = GameObject.Find("Sonido queja").GetComponent<AudioSource> ();

		this.botonContinuar.SetActive (false);
		this.botonTerminar.SetActive (false);
		this.resultado.SetActive (false);
	}

	public void setFinalizado() {
		this.finalizado = true;
	}

	public void comenzarCuantaAtras() {
		StartCoroutine (waitFor ());
	}

	public void activarResultadoVictoria() {
		this.audioFondo.Stop ();

		this.resultado.SetActive (true);
		this.botonContinuar.SetActive (true);
	}

	public void activarResultadoDerrota() {
		this.mensajeTitulo.color = Color.red;
		this.mensajeTitulo.text = "¡Has perdido el duelo!";
		this.mensajeExplicacion.text = "Marcelo te ha disparado primero, y te ha herido de muerte.";
		this.botonTerminar.SetActive (true);
		this.resultado.SetActive (true);
	}

	public void cargarEscenaVictoria() {
		GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("scene4.3.2");
	}

	public void cargarFinalDerrota() {
		VariablesGenerales.Instance.setFinal("muerte");
		GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("FinalJuego");
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds(segundos);
		if (!this.finalizado) {
			this.marcelo.SetBool ("empezar", false);
			this.marcelo.SetBool ("disparar", true);
			this.botonDisparo.SetActive(false);
			this.botonRecarga.SetActive(false);
			this.contenedorRecarga.SetActive(false);
			StartCoroutine (waitForSegundo ());
		}
	}
	
	IEnumerator waitForSegundo(){
		yield return new WaitForSeconds(1.5f);
		this.audioDisparo.Play ();
		yield return new WaitForSeconds(0.4f);
		this.audioQueja.Play ();
		this.audioFondo.Stop();
		this.activarResultadoDerrota ();
	}
}