using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorFinalJuego : MonoBehaviour {
	
	private AudioSource audioTriste;
	private AudioSource audioAlegre;
	
	private Image fondoBodaDonJuan;
	private Image fondoMuerte;
	private Image fondoBodaMarcelo;
	private Image fondoMonja;
	private Image fondoTelon;
	private Image botonSalir;
	private Image botonResultados;
	
	private GameObject resultado;
	private Text mensajeFinal;
	private Text notaBosque;
	private Text notaPuerto;
	private Text notaPosada;
	private Text notaToledo;
	private Text totalRatones;
	private Text totalHonor;
	
	private GameObject textoCreditos;
	
	private string tipoFinal;
	
	private Creditos creditos;
	
	void Start () {
		//EasterEgg
		if (VariablesGenerales.Instance.getRatonesEncontrados () >= 3) {
			VariablesGenerales.Instance.activarEasterEggRaton ();
		}
		
		VariableJuegoPasado.Instance.setJuegoPasado ();
		
		this.audioTriste = GameObject.Find ("SonidoTriste").GetComponent<AudioSource>();
		this.audioAlegre = GameObject.Find ("SonidoAlegre").GetComponent<AudioSource>();
		
		this.resultado = GameObject.Find ("ResultadoFinal");
		this.mensajeFinal = GameObject.Find ("FraseFinal").GetComponent<Text>();
		this.notaBosque = GameObject.Find ("NotaBosque").GetComponent<Text>();
		this.notaPuerto = GameObject.Find ("NotaPuerto").GetComponent<Text>();
		this.notaPosada = GameObject.Find ("NotaPosada").GetComponent<Text>();
		this.notaToledo = GameObject.Find ("NotaToledo").GetComponent<Text>();
		this.totalRatones = GameObject.Find ("TotalRatones").GetComponent<Text>();
		this.totalHonor = GameObject.Find ("TotalHonor").GetComponent<Text>();
		
		this.textoCreditos = GameObject.Find ("TextoCreditos");
		
		this.fondoBodaDonJuan = GameObject.Find ("BodaDonJuanLucrecia").GetComponent<Image>();
		this.fondoMuerte = GameObject.Find ("DonJuanMuerto").GetComponent<Image>();
		this.fondoBodaMarcelo = GameObject.Find ("BodaMarceloLucrecia").GetComponent<Image>();
		this.fondoMonja = GameObject.Find ("LucreciaMonja").GetComponent<Image>();
		this.fondoTelon = GameObject.Find ("TelonSolo").GetComponent<Image>();
		this.botonSalir = GameObject.Find ("BotonSalir").GetComponent<Image>();
		this.botonResultados = GameObject.Find ("BotonResultados").GetComponent<Image>();
		
		this.textoCreditos.SetActive (false);
		this.resultado.SetActive (false);
		this.botonSalir.enabled = false;
		
		if (VariablesGenerales.Instance.getFinal () != null)
			this.tipoFinal = VariablesGenerales.Instance.getFinal ();
		else
			this.tipoFinal = "";

		//Libera el Dialog system para que se vuelva a crear en el menu
		PixelCrushers.DialogueSystem.DialogueManager.ResetDatabase (PixelCrushers.DialogueSystem.DatabaseResetOptions.RevertToDefault);
		
		switch (this.tipoFinal) {
			
		case "muerte":
			this.mensajeFinal.text = "Has muerto por la mujer a la que amabas. Tu honor ha quedado intacto";
			this.fondoBodaDonJuan.enabled = false;
			this.fondoBodaMarcelo.enabled = false;
			this.fondoMonja.enabled = false;
			this.fondoTelon.enabled = false;
			this.audioTriste.Play();
			break;
			
		case "bodaDonJuan":
			this.mensajeFinal.text = "Has demostrado ser un hombre de honor, y al final has sido recompensado cansandote con la mujer a la que amas";
			this.fondoMuerte.enabled = false;
			this.fondoBodaMarcelo.enabled = false;
			this.fondoMonja.enabled = false;
			this.fondoTelon.enabled = false;
			this.audioAlegre.Play();
			VariablesGenerales.Instance.aumentarTareasOpcionalesCompletas (); //Por la mision opcional de boda
			VariablesGenerales.Instance.aumentarTareasCompletas (); //Por la mision opcional de boda
			break;
			
		case "bodaMarcelo":
			this.mensajeFinal.text = "Has dejado a otro hombre casarse con la mujer que amas, ello demuestra que eres un hombre honorable";
			this.fondoBodaDonJuan.enabled = false;
			this.fondoMuerte.enabled = false;
			this.fondoMonja.enabled = false;
			this.fondoTelon.enabled = false;
			this.audioTriste.Play();
			VariablesGenerales.Instance.aumentarTareasOpcionalesCompletas (); //Por la mision opcional de boda
			VariablesGenerales.Instance.aumentarTareasCompletas (); //Por la mision opcional de boda
			break;
			
		case "monja":
			this.mensajeFinal.text = "Tu codicia y falta de honor han provocado que Lucrecia decida hacerse monja. No has conseguido que se enamorara de ti";
			this.fondoBodaDonJuan.enabled = false;
			this.fondoMuerte.enabled = false;
			this.fondoBodaMarcelo.enabled = false;
			this.fondoTelon.enabled = false;
			this.audioTriste.Play();
			break;
			
		case "monja_echada":
			this.mensajeFinal.text = "Has acusado a Lucrecia de infiel provocando que se haga monja. Has seguido tus instintos pero no ha sido honorable";
			this.fondoBodaDonJuan.enabled = false;
			this.fondoMuerte.enabled = false;
			this.fondoBodaMarcelo.enabled = false;
			this.fondoTelon.enabled = false;
			this.audioTriste.Play();
			break;
			
		default:
			this.mensajeFinal.enabled = false;
			this.botonSalir.enabled = true;
			this.botonResultados.enabled = false;
			this.textoCreditos.SetActive (true);
			this.fondoBodaDonJuan.enabled = false;
			this.fondoBodaMarcelo.enabled = false;
			this.fondoMonja.enabled = false;
			this.fondoMuerte.enabled = false;
			this.audioAlegre.Play();
			break;
		}
	}
	
	private void calcularMisiones() {
		int totalBosque = VariablesGenerales.Instance.getTotalTareasBosque();
		int totalPuerto = VariablesGenerales.Instance.getTotalTareasPuerto();
		int totalPosada = VariablesGenerales.Instance.getTotalTareasPosada();
		int totalToledo = VariablesGenerales.Instance.getTotalTareasToledo();
		
		int bosque = totalBosque;
		int puerto = totalPuerto;
		int posada = totalPosada;
		int toledo = totalToledo;
		
		if (!VariablesGenerales.Instance.getTareaEspecialBosque())
			bosque--;
		
		if (!VariablesGenerales.Instance.getTareaEspecialMendigo())
			puerto--;
		
		if (!VariablesGenerales.Instance.getTareaEspecialComprarDuenas())
			puerto--;
		
		if (!VariablesGenerales.Instance.getTareaEspecialClientes())
			posada--;
		
		if (!VariablesGenerales.Instance.getTareaEspecialDescubrirRuidos())
			posada--;
		
		if (!VariablesGenerales.Instance.getTareaEspecialRobarPosadero())
			posada--;
		
		if (!VariablesGenerales.Instance.getTareaEspecialBatirseDuelo())
			toledo--;
		
		if (VariablesGenerales.Instance.getFinal() == "bodaDonJuan" && VariablesGenerales.Instance.getFinal() == "bodaMarcelo")
			toledo--;
		
		this.notaBosque.text = bosque.ToString () + " / " + totalBosque.ToString ();
		this.notaPuerto.text = puerto.ToString () + " / " + totalPuerto.ToString ();
		this.notaPosada.text = posada.ToString () + " / " + totalPosada.ToString ();
		this.notaToledo.text = toledo.ToString () + " / " + totalToledo.ToString ();
		this.totalRatones.text = VariablesGenerales.Instance.getRatonesEncontrados () + " / 3";
		this.totalHonor.text = VariablesGenerales.Instance.getCortesiaActual () + " / 100";
	}
	
	public void mostrarResultados() {
		this.botonResultados.enabled = false;
		this.calcularMisiones();
		this.resultado.SetActive (true);
	}
	
	public void cerrarResultados() {
		this.resultado.SetActive (false);
		this.mensajeFinal.enabled = false;
		this.fondoTelon.enabled = true;
		this.fondoBodaDonJuan.enabled = false;
		this.fondoBodaMarcelo.enabled = false;
		this.fondoMonja.enabled = false;
		this.fondoMuerte.enabled = false;
		this.botonSalir.enabled = true;
		this.textoCreditos.SetActive (true);
	}
}