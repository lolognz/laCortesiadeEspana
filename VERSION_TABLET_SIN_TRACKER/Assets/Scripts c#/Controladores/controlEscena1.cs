using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlEscena1 : MonoBehaviour {
	private GameObject zorrilla;
	private GameObject zorrilla1;
	private float segundos = 6f;
	
	private variablesHUD varHUD;
	private Button botonPause;
	private BoxCollider2D cofre;
	private controladorEscena control;
	
	//Tutorial
	private GameObject tutorialCaminar;
	private GameObject tutorialCofre;
	private GameObject tutorialLucrecia;
	private Image flechaDinero;
	private Image flechaHonor;
	private Image flechaAgenda;
	
	private bool tutorialLucreciaActivado = false;
	private bool lucreciaSalvada = false;
	
	void Start () {
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();
		this.varHUD = GameObject.Find ("HUD").GetComponent<variablesHUD> ();
		this.botonPause = GameObject.Find ("BotonPause").GetComponent<Button> ();
		this.cofre = GameObject.Find ("Cofre").GetComponent<BoxCollider2D> ();
		
		this.tutorialCaminar = GameObject.Find ("TutoCaminar");
		this.tutorialCofre = GameObject.Find ("TutoCofre");
		this.tutorialLucrecia = GameObject.Find ("TutoLucrecia");
		this.flechaDinero = GameObject.Find ("FlechaDinero").GetComponent<Image>();
		this.flechaHonor = GameObject.Find ("FlechaHonor").GetComponent<Image>();
		this.flechaAgenda = GameObject.Find ("FlechaAgenda").GetComponent<Image>();
		
		//Hasta que no acabe el tutorial de caminar no habilitamos el cofre.
		this.cofre.enabled = false;
		
		this.tutorialCaminar.SetActive (false);
		this.tutorialCofre.SetActive (false);
		this.tutorialLucrecia.SetActive (false);
		this.flechaDinero.enabled = false;
		this.flechaHonor.enabled = false;
		this.flechaAgenda.enabled = false;
		
		this.zorrilla = GameObject.Find ("Zorrilla.");
		this.zorrilla1 = GameObject.Find ("Zorrilla");
		this.zorrilla1.SetActive (false);
	}
	
	void Update() {
		if (Input.GetMouseButton (0)) {
			if (this.tutorialLucreciaActivado)
				this.desactivarTutorialLucrecia ();
		}
	}
	
	public void caminarZorrilla(){
		this.activarTutorialCaminar ();
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminando", true);
		StartCoroutine (waitFor ());
	}
	
	IEnumerator waitFor(){
		yield return new WaitForSeconds(segundos);
		this.zorrilla.GetComponent<Animator> ().SetBool ("caminando", false);
		Destroy (this.zorrilla);
		this.zorrilla1.SetActive (true);
	}
	
	public void activarTutorialCaminar() {
		this.botonPause.interactable = false;
		this.flechaAgenda.enabled = true;
		this.tutorialCaminar.SetActive (true);
		Time.timeScale = 0f;
	}
	
	public void desactivarTutorialCaminar() {
		this.botonPause.interactable = true;
		this.flechaAgenda.enabled = false;
		this.tutorialCaminar.SetActive (false);
		Time.timeScale = 1f;
		//Activamos el colider del cofre
		this.cofre.enabled = true;
	}
	
	public void activarTutorialCofre() {
		this.botonPause.interactable = false;
		this.tutorialCofre.SetActive (true);
		this.flechaDinero.enabled = true;
		this.flechaHonor.enabled = true;
		Time.timeScale = 0f;
	}
	
	public void desactivarTutorialCofre() {
		this.control.marcarTareaCompleta (0, true, false);	//Completar tutorial
		this.botonPause.interactable = true;
		this.tutorialCofre.SetActive (false);
		this.flechaDinero.enabled = false;
		this.flechaHonor.enabled = false;
		Time.timeScale = 1f;
		GameObject.Find("Cofre").GetComponent<cogerCofres>().abrirCofre(true); //Abrimos cofre y quitamos cortesia
	}
	
	public void activarTutorialLucrecia() {
		if (!VariablesGenerales.Instance.getCofreAbierto () && !this.lucreciaSalvada) {
			this.lucreciaSalvada = true;
			this.tutorialLucreciaActivado = true;
			this.botonPause.interactable = false;
			this.tutorialLucrecia.SetActive (true);
			this.flechaHonor.enabled = true;
			this.flechaDinero.enabled = true;
			//Time.timeScale = 0f;
		}
	}
	
	public void desactivarTutorialLucrecia() {
		this.control.marcarTareaCompleta (0, true, false);	//Completar tutorial
		this.tutorialLucreciaActivado = false;
		//this.botonPause.interactable = true;
		this.tutorialLucrecia.SetActive (false);
		this.flechaDinero.enabled = false;
		this.flechaHonor.enabled = false;
		//Time.timeScale = 1f;
		this.varHUD.aumentaCortesia(10);
	}
	
	public bool getLucreciaSalvada() {
		return this.lucreciaSalvada;
	}
}