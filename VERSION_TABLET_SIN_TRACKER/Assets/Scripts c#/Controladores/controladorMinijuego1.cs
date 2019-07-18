using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controladorMinijuego1 : MonoBehaviour {

	private int toques;	//Veces que el jugador esquiva un objeto
	private int vidas;
	private float tiempoInicio;
	private float tiempoTotalMinijuego;

	private Image vida1;
	private Image vida2;
	private Image vida3;

	private AudioSource audioGolpe;
	private AudioSource audioPisadas;

	public Sprite zorrillaBoton;

	private GameObject resultados;
	private Text totalObjetos;
	private Text totalTiempo;
	private Text totalDinero;

	//Animaciones de juego
	private Generador generador1;
	private Generador generador2;
	private Generador generador3;
	private Generador generador4;
	private Animator claudio;
	private Animator fondo;
	
	void Start () {
		this.toques = 0;
		this.vidas = 3;
		this.tiempoInicio = 0;
		this.tiempoTotalMinijuego = 0;

		this.generador1 = GameObject.Find ("Generador DR").GetComponent<Generador> ();
		this.generador2 = GameObject.Find ("Generador UL").GetComponent<Generador> ();
		this.generador3 = GameObject.Find ("Generador UR").GetComponent<Generador> ();
		this.generador4 = GameObject.Find ("Generador DL").GetComponent<Generador> ();
		this.claudio = GameObject.Find ("Claudio").GetComponent<Animator> ();
		this.fondo = GameObject.Find ("FondoArboles").GetComponent<Animator> ();

		this.audioGolpe = this.gameObject.GetComponent<AudioSource> ();
		this.audioPisadas = GameObject.Find("Sonido fondo").GetComponent<AudioSource>();

		this.vida1 = GameObject.Find ("Vida1").GetComponent<Image> ();
		this.vida2 = GameObject.Find ("Vida2").GetComponent<Image> ();
		this.vida3 = GameObject.Find ("Vida3").GetComponent<Image> ();

		if (!VariablesGenerales.Instance.donJuanPersigueClaudio ()) { //Si mandas a zorrilla a perseguir, sale su cara en las vidas
			this.vida1.sprite = this.zorrillaBoton;
			this.vida2.sprite = this.zorrillaBoton;
			this.vida3.sprite = this.zorrillaBoton;
		}

		this.vida1.enabled = false;
		this.vida2.enabled = false;
		this.vida3.enabled = false;

		this.resultados = GameObject.Find("FondoResultado");
		this.totalObjetos = GameObject.Find ("TotalObjetos").GetComponent<Text> ();
		this.totalTiempo = GameObject.Find ("TotalTiempo").GetComponent<Text> ();
		this.totalDinero = GameObject.Find ("TotalDinero").GetComponent<Text> ();
		this.resultados.SetActive(false);

		//Registramos el objetivo de que hemos jugado al minijuego(Perseguir al malhechor).
		VariablesGenerales.Instance.completarTareaEspecialBosque();
	}

	public void aumentarToques() {
		this.toques++;
	}

	public void perderVda() {
		this.vidas--;
		this.audioGolpe.Play ();

		switch (this.vidas) {
		case 0:
			this.vida3.enabled = false;
			this.desactivarJuego();
			this.mostrarResultados();
			break;

		case 1:
			this.vida2.enabled = false;
			break;

		case 2:
			this.vida1.enabled = false;
			break;
		}
	}

	public int obtenerToques() {
		return this.toques;
	}

	public int obtenerVidas() {
		return this.vidas;
	}

	//LLamado por el tutorial, comienza ha transcurrir el tiempo desde ahi.
	public void setTiempoInicio(float tiempo) {
		this.tiempoInicio = tiempo;
	}

	//El tiempo total es la diferencia entre el tiempo de finalizacion y el obtenido al empezar.
	public float obtenerTiempoTranscurrido() {
		return Mathf.Round(this.tiempoTotalMinijuego - this.tiempoInicio);
	}

	public void siguienteEscena() {
		GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("scene1.2");
	}

	private void mostrarResultados() {
		this.tiempoTotalMinijuego = Time.time; //Obtenemos el tiempo actual ya que es la ultima vida.
		int dineroGanado = this.toques * 5;

		if (dineroGanado > 100)
			dineroGanado = 100;

		if (this.audioPisadas.isPlaying)
			this.audioPisadas.Stop();

		this.totalObjetos.text = this.toques.ToString();
		this.totalDinero.text = dineroGanado.ToString();
		this.totalTiempo.text = obtenerTiempoTranscurrido().ToString() + " sg";

		this.resultados.SetActive (true);

		//Aumentamos el dinero ganado en variables generales.
		VariablesGenerales.Instance.aumentaDinero (dineroGanado);
		//Debug.Log("Tiempo transcurrido: " + obtenerTiempoTranscurrido().ToString());
	}

	public void desactivarTutorial() {
		GameObject.Find ("Tutorial").SetActive (false);
		this.generador1.activo = true;
		this.generador2.activo = true;
		this.generador3.activo = true;
		this.generador4.activo = true;
		this.claudio.enabled = true;
		this.fondo.enabled = true;
		this.audioPisadas.Play ();
		this.setTiempoInicio (Time.time);
		this.vida1.enabled = true;
		this.vida2.enabled = true;
		this.vida3.enabled = true;
	}

	private void desactivarJuego() {
		this.generador1.activo = false;
		this.generador2.activo = false;
		this.generador3.activo = false;
		this.generador4.activo = false;
		this.claudio.enabled = false;
		this.fondo.enabled = false;
	}
}