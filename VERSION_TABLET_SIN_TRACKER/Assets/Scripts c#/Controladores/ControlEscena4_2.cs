using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlEscena4_2 : MonoBehaviour {

	private controladorEscena control;
	private AudioSource musicaFondo;
	private GameObject hud;
	private Text mensaje;
	private GameObject fondoNegro;

	private bool quitado = false;

	void Start () {
		this.control = this.gameObject.GetComponent<controladorEscena> ();
		this.control.marcarTareaCompleta (0);	//Completada en la escena 4.
		this.control.marcarTareaCompleta (1);	//Completada en la escena 4.

		this.mensaje = GameObject.Find ("Mensaje").GetComponent<Text>();
		this.fondoNegro = GameObject.Find ("FondoNegro");

		if (VariablesGenerales.Instance.getMensajeMarceloInterrumpeBoda ())
			this.mensaje.text = "... Minutos mas tarde suena la puerta de casa";

		this.hud = GameObject.Find("HUD");
		this.hud.SetActive (false);

		this.musicaFondo = GameObject.Find ("Sonido fondo").GetComponent<AudioSource>();
		this.hud.SetActive (false);
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			if (!quitado) {
				this.quitado = true;
				this.mensaje.enabled = false;
				this.fondoNegro.SetActive(false);
				this.hud.SetActive (true);
				this.musicaFondo.Play ();
			}
		}
	}
}