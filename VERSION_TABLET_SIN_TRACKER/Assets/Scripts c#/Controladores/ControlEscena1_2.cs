using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlEscena1_2 : MonoBehaviour {

	private controladorEscena control;
	private Button siguiente;
	private GameObject tutorial;
	private Button botonPause;

	private bool activado = false; //Se utiliza para controlar que el tutorial de siguiente escena se active solo la primera vez.

	void Start () {
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();
		Debug.Log (this.control.name);
		try{
			this.control.marcarTareaCompleta (0);	//Completada en la escena 1.
			this.control.marcarTareaCompleta (1);	//Completada en la escena 1.

			if (VariablesGenerales.Instance.getTareaEspecialBosque ())	//Si ha habido minijuego o no.
				this.control.marcarTareaCompleta (2, true, true);
			else
				this.control.marcarTareaFallida (2);
		}catch{
		}
		this.control.marcarTareaCompleta (3, true, false);	//Se completa al iniciar esta escena.
		VariablesGenerales.Instance.aumentarTareasCompletas (); //Aumentamos una por la salida del bosque que se va a hacer.

		this.siguiente = GameObject.Find ("BotonSiguienteEscena").GetComponent<Button>();
		this.siguiente.interactable = false;

		this.tutorial = GameObject.Find ("Tutorial");
		this.tutorial.SetActive (false);

		this.botonPause = GameObject.Find ("BotonPause").GetComponent<Button> ();
	}

	public void habilitaEscenaSiguiente() {
		if (!this.activado) {
			this.activado = true;
			this.activarTutorial();
			this.siguiente.interactable = false;
		}

		else 
			this.siguiente.interactable = true;
	}

	public void desHabilitaEscenaSiguiente() {
		this.siguiente.interactable = false;
	}

	public void activarTutorial() {
		this.tutorial.SetActive (true);
		this.botonPause.interactable = false;
		Time.timeScale = 0f;
	}

	public void desactivarTutorial() {
		this.tutorial.SetActive (false);
		this.siguiente.interactable = true;
		this.botonPause.interactable = true;
		Time.timeScale = 1f;
		GameObject.Find ("BotonSiguienteEscena").GetComponent<EfectoParpadeo> ().enabled = true;
	}
}