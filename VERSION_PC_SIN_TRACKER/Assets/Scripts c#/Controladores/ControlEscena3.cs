using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlEscena3 : MonoBehaviour {

	private GameObject zorrilla;
	private GameObject zorrilla1;
	private float segundosZorrilla = 5.30f;
	private GameObject lucrecia;
	private GameObject lucrecia1;
	private float segundosLucrecia = 5.90f;

	private controladorEscena control;
	private Button siguiente;

	private bool cliente1Hablado = false;
	private bool cliente2Hablado = false;
	
	void Start () {
		this.zorrilla = GameObject.Find ("Zorrilla");
		this.zorrilla1 = GameObject.Find ("Zorrilla.");
		this.zorrilla1.SetActive (false);
		this.lucrecia = GameObject.Find ("Lucrecia");
		this.lucrecia1 = GameObject.Find ("Lucrecia.");
		this.lucrecia1.SetActive (false);
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();

		this.siguiente = GameObject.Find ("BotonSiguienteEscena").GetComponent<Button>();
		this.siguiente.interactable = false;
	}

	public void caminarZorrilla(){
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoPosada", true);
		StartCoroutine (waitFor2 ());
	}
	
	IEnumerator waitFor2(){
		yield return new WaitForSeconds(segundosZorrilla);
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoPosada", false);
		Destroy (this.zorrilla);
		this.zorrilla1.SetActive (true);
	}

	public void caminarLucrecia(){
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoPosada", true);
		StartCoroutine (waitFor ());
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds(segundosLucrecia);
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoPosada", false);
		Destroy (this.lucrecia);
		this.lucrecia1.SetActive (true);
	}

	//Marcamos si se ha hablado con cualquiera de los clientes y comprobamos si se debe marcar el objetivo.
	public void hablarConCliente1() {
		this.cliente1Hablado = true;
		this.marcarTareaHablarCliente ();
	}

	public void hablarConCliente2() {
		this.cliente2Hablado = true;
		this.marcarTareaHablarCliente ();
	}

	public void marcarTareaHablarCliente() {
		if (this.cliente1Hablado && this.cliente2Hablado) {
			if (!VariablesGenerales.Instance.getTareaEspecialClientes()) { //Con esto controlamos que solo se marque la primera vez
				VariablesGenerales.Instance.completarTareaEspecialClientes ();
				this.control.marcarTareaCompleta(0, true, true);
			}
		}
	}

	public void habilitaEscenaSiguiente(){
		GameObject.Find ("BotonSiguienteEscena").GetComponent<EfectoParpadeo> ().enabled = true;
		this.siguiente.interactable = true;
	}

	public void desHabilitaEscenaSiguiente(){
		this.siguiente.interactable = false;
	}
}