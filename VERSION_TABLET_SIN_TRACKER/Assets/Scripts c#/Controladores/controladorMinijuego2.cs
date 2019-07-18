using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controladorMinijuego2 : MonoBehaviour {
	
	private GameObject tutorial;
	private GameObject resultado;
	private GameObject resultadoMal;
	private GameObject botonContinuar;
	private GameObject mensajeSolucion;
	private GameObject mensajeSolucion2;
	private GameObject barraMiedo;
	
	private float tiempoMinijuego = 0f;
	
	private Image solucion;
	private Image barraVerdeMiedo;
	private Button botonSolucion;
	
	public Sprite imagenZorrilla;
	public Sprite barraRojaMiedo;
	
	private bool rellenar = false;
	private bool encontrado = false;
	private bool finTutorial = false;
	
	private AudioSource audioPisadas;
	
	public float tiempo_maximo = 15f;
	
	void Start () {
		Time.timeScale = 0f;
		this.tutorial = GameObject.Find ("Tutorial");
		this.resultado = GameObject.Find ("Resultado");
		this.resultadoMal = GameObject.Find ("ResultadoMal");
		this.solucion = GameObject.Find ("ZorrillaSolucion").GetComponent<Image>();
		this.botonSolucion = GameObject.Find ("ZorrillaSolucion").GetComponent<Button>();
		this.botonContinuar = GameObject.Find ("BotonContinuar");
		this.mensajeSolucion = GameObject.Find ("MensajeSolucion");
		this.mensajeSolucion2 = GameObject.Find ("MensajeSolucion2");
		this.barraMiedo = GameObject.Find("BarraMiedo");
		this.barraVerdeMiedo = GameObject.Find ("barraVerde").GetComponent<Image> ();
		this.audioPisadas = GameObject.Find ("Sonido fondo").GetComponent<AudioSource>();
		
		this.mensajeSolucion.SetActive (false);
		this.mensajeSolucion2.SetActive (false);
		this.botonContinuar.SetActive (false);
		this.resultado.SetActive (false);
		this.resultadoMal.SetActive (false);
		this.barraMiedo.SetActive (false);
		this.barraVerdeMiedo.fillAmount = 0;
		this.solucion.fillAmount = 0;
		this.botonSolucion.interactable = false;
	}
	
	void FixedUpdate() {
		if (!this.encontrado & this.finTutorial) {
			if (this.barraVerdeMiedo.fillAmount >= 0.75) {
				this.barraVerdeMiedo.sprite = this.barraRojaMiedo;
			}
			
			this.barraVerdeMiedo.fillAmount += (1/this.tiempo_maximo) * Time.deltaTime;
			
			if (Time.time - this.tiempoMinijuego >= this.tiempo_maximo) {
				this.finDelTiempo();
			}
		}
		
		if (this.rellenar && this.solucion.fillAmount < 1) {
			this.solucion.fillAmount += 1f*Time.deltaTime;
		}
		
		if (this.solucion.fillAmount >= 1) {
			this.mensajeSolucion2.SetActive (true);
			this.botonSolucion.interactable = true;
		}
	}
	
	public void desactivarTutorial() {
		this.tutorial.SetActive (false);
		this.audioPisadas.Play ();
		this.barraMiedo.SetActive (true);
		this.tiempoMinijuego = Time.time;
		Time.timeScale = 1f;
		this.finTutorial = true;
	}
	
	public void terminarJuego() {
		VariablesGenerales.Instance.completarTareaEspecialDescubrirRuidos ();
		this.encontrado = true;
		this.audioPisadas.Stop ();
		this.resultado.SetActive (true);
		this.rellenar = true;
	}
	
	public void destaparSolucion() {
		this.gameObject.GetComponent<AudioSource> ().Play ();
		this.solucion.sprite = this.imagenZorrilla;
		this.mensajeSolucion.SetActive (true);
		this.botonContinuar.SetActive (true);
	}
	
	private void finDelTiempo() {
		this.audioPisadas.Stop ();
		this.resultadoMal.SetActive (true);
	}
	
	// Si lo encontramos pasamos a la escena 3.2.2
	public void cambiarEscena() {
		if (this.encontrado)
			GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("scene3.2.2");
		else
			GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("scene3.3");
	}
}