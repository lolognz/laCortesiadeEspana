using UnityEngine;
using System.Collections;

public class ControlEscena4 : MonoBehaviour {
	private GameObject zorrilla;
	private GameObject zorrilla1;
	private float segundosZorrilla = 8f;
	private GameObject lucrecia;
	private GameObject lucrecia1;
	private float segundosLucrecia = 9f;

	void Start () {
		this.zorrilla = GameObject.Find ("Zorrilla");
		this.zorrilla1 = GameObject.Find ("Zorrilla.");
		this.zorrilla1.SetActive (false);
		this.lucrecia = GameObject.Find ("Lucrecia");
		this.lucrecia1 = GameObject.Find ("Lucrecia.");
		this.lucrecia1.SetActive (false);
	}

	public void caminarZorrilla(){
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoToledo", true);
		StartCoroutine (waitFor2 ());
	}
	
	IEnumerator waitFor2(){
		yield return new WaitForSeconds(segundosZorrilla);
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminandoToledo", false);
		Destroy (this.zorrilla);
		this.zorrilla1.SetActive (true);
	}
	
	public void caminarLucrecia(){
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoToledo", true);
		StartCoroutine (waitFor ());
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds(segundosLucrecia);
		this.lucrecia.GetComponent<Animator> ().SetBool ("caminandoToledo", false);
		Destroy (this.lucrecia);
		this.lucrecia1.SetActive (true);
	}
}