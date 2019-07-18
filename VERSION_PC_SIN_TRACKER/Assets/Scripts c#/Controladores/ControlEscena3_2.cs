using UnityEngine;
using System.Collections;

public class ControlEscena3_2 : MonoBehaviour {

	private GameObject cortinaNegra;
	private GameObject hud;
	private controladorEscena control;

	private GameObject mensaje;

	private AudioSource abrirPuerta;
	private AudioSource pisadas;
	private bool quitado = false;

	void Start () {
		//Tareas
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();
		if (VariablesGenerales.Instance.getTareaEspecialClientes ())
			this.control.marcarTareaCompleta (0);
		else
			this.control.marcarTareaFallida (0);

		this.control.marcarTareaCompleta (1);
		this.control.marcarTareaCompleta (2);
		this.control.marcarTareaCompleta (3, true, false);

		//Mecanica de la escena
		this.mensaje = GameObject.Find ("Mensaje");
		this.cortinaNegra = GameObject.Find("CortinaNegra");
		this.hud = GameObject.Find("HUD");
		this.abrirPuerta = this.gameObject.GetComponent<AudioSource> ();
		this.pisadas = GameObject.Find ("Sonido Pisadas").GetComponent<AudioSource> ();

		this.hud.SetActive (false);
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			if (!quitado) {
				this.quitado = true;
				this.pisadas.Stop ();
				this.abrirPuerta.Play ();
				this.mensaje.SetActive (false);
				this.cortinaNegra.SetActive (false);
				this.hud.SetActive (true);
			}
		}
	}
}