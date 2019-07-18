using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlEscena2 : MonoBehaviour {
	private GameObject zorrilla;
	private GameObject zorrilla1;
	private float segundosZorrilla = 5.90f;
	private GameObject lucrecia;
	private GameObject lucrecia1;
	private float segundosLucrecia = 7.30f;
	private controladorEscena control;
	private Button siguiente;

	void Start () {
		this.zorrilla = GameObject.Find ("Zorrilla");
		this.zorrilla1 = GameObject.Find ("Zorrilla.");
		this.zorrilla1.SetActive (false);
		this.lucrecia = GameObject.Find ("Lucrecia");
		this.lucrecia1 = GameObject.Find ("Lucrecia.");
		this.lucrecia1.SetActive (false);
		VariablesGenerales.Instance.aumentarTareasCompletas (); //Aumentamos una tarea completa por la salida del puerto que se va a hacer
		this.siguiente = GameObject.Find ("BotonSiguienteEscena").GetComponent<Button>();
		this.siguiente.interactable = false;
	}
	
	public void caminarZorrilla(){
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoPuerto", true);
		StartCoroutine (waitFor2 ());
	}
	
	IEnumerator waitFor2(){
		yield return new WaitForSeconds(segundosZorrilla);
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoPuerto", false);
		Destroy (this.zorrilla);
		this.zorrilla1.SetActive (true);
	}
	
	public void caminarLucrecia(){
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoPuerto", true);
		StartCoroutine (waitFor ());
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds(segundosLucrecia);
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoPuerto", false);
		Destroy (this.lucrecia);
		this.lucrecia1.SetActive (true);
	}
	
	public void habilitaEscenaSiguiente(){
		GameObject.Find ("BotonSiguienteEscena").GetComponent<EfectoParpadeo> ().enabled = true;
		this.siguiente.interactable = true;
	}
	public void desHabilitaEscenaSiguiente(){
		this.siguiente.interactable = false;
	}
}