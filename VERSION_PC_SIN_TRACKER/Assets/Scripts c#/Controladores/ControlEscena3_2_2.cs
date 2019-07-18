using UnityEngine;
using System.Collections;

public class ControlEscena3_2_2 : MonoBehaviour {

	private controladorEscena control;
	private GameObject zorrilla;
	private GameObject lucrecia;
	private GameObject lucrecia1;
	private float segundosLucrecia = 3f;
	private float segundosZorrilla = 4f;
	private variablesHUD varHUD;

	void Start () {
		this.varHUD = GameObject.Find ("HUD").GetComponent<variablesHUD> ();
		this.varHUD.aumentaCortesia (10);
		this.zorrilla = GameObject.Find ("Zorrilla");
		this.lucrecia = GameObject.Find ("Lucrecia");
		this.lucrecia1 = GameObject.Find ("Lucrecia_1");
		this.lucrecia.SetActive(false);
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();
		if (VariablesGenerales.Instance.getTareaEspecialClientes ())
			this.control.marcarTareaCompleta (0);
		else
			this.control.marcarTareaFallida (0);
		
		this.control.marcarTareaCompleta (1);
		this.control.marcarTareaCompleta (2);
		this.control.marcarTareaCompleta (3);

		if (VariablesGenerales.Instance.getTareaEspecialDescubrirRuidos ())
			this.control.marcarTareaCompleta (4, true, true);
		else
			this.control.marcarTareaFallida (4);
	}

	public void caminarZorrillaSalir(){
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoNocheSalir", true);
		StartCoroutine (waitFor2 ());
	}
	
	IEnumerator waitFor2(){
		yield return new WaitForSeconds(segundosZorrilla);
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoNocheSalir", false);
		Destroy (this.zorrilla);
	}

	public void caminarLucrecia(){
		this.lucrecia1.GetComponent<Animator> ().SetBool ("caminandoNoche", true);
		StartCoroutine (waitFor ());
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds(segundosLucrecia);
		this.lucrecia1.GetComponent<Animator> ().SetBool ("caminandoNoche", false);
		Destroy (this.lucrecia1);
		this.lucrecia.SetActive (true);
	}

	public void caminarLucreciaSalir(){
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoNocheSalir", true);
		StartCoroutine (waitFor3 ());
	}
	
	IEnumerator waitFor3(){
		yield return new WaitForSeconds(segundosLucrecia);
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoNocheSalir", false);
		Destroy (this.lucrecia);
	}
}