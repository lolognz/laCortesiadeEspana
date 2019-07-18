using UnityEngine;
using System.Collections;

public class cogerCofres : MonoBehaviour {

	public Sprite cofreCerrado; // Drag your first sprite here
	public Sprite cofreAbierto; // Drag your second sprite here

	private SpriteRenderer sr;

	private variablesHUD varHUD;
	private controlEscena1 control;

	void Start() {
		if (GameObject.Find ("ControladorEscena").GetComponent<controlEscena1> () != null)
			this.control = GameObject.Find ("ControladorEscena").GetComponent<controlEscena1> ();

		if (VariablesGenerales.Instance.getCofreAbierto ())
			this.gameObject.GetComponent<SpriteRenderer>().sprite = cofreAbierto;

		else
			this.gameObject.GetComponent<SpriteRenderer>().sprite = cofreCerrado;

		this.varHUD = GameObject.Find ("HUD").GetComponent<variablesHUD> ();
	}
	
	void OnMouseDown() {
		if (!VariablesGenerales.Instance.getCofreAbierto ()) {
			if (this.control != null) {	//Es primera escena o no
				if (this.control.getLucreciaSalvada()) {	//Si el tutorial se ha acabado
					this.abrirCofre();
				}
				
				else {	//Se ha escogido el cofre antes de hablar con Lucrecia
					GameObject.Find("ControladorEscena").GetComponent<controlEscena1>().activarTutorialCofre();
				}
			}

			else { //Esto significa que no es la primera escena por lo que no hay tutorial.
				this.abrirCofre();
			}
		}
	}

	public void abrirCofre(bool tutorial = false) {
		VariablesGenerales.Instance.setCofreAbierto (); //Cambiamos el estado a abierto
		this.varHUD.aumentaDinero(50);
		this.gameObject.GetComponent<SpriteRenderer>().sprite = cofreAbierto;

		if (tutorial) {
			this.varHUD.aumentaCortesia(-10);
		}
	}
}