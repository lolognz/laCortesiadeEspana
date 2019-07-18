using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSalir : MonoBehaviour {
	
	private bool paused = false;
	private bool agenda = false;
	private bool salir = false;
	
	public Font fuente;
	public Texture fondo;
	public Texture boton1;
	public Texture boton2;
	public Texture boton3;
	public Texture boton4;
	public Texture boton5;
	public Texture checkDesactivado;
	public Texture checkTareaCompleta;
	public Texture checkTareaFallida;
	
	private Button botonPausa;
	private GameObject donJuan;
	
	private GUIStyle FuenteTareaInincial;
	private GUIStyle FuenteTareaCompleta;
	private GUIStyle FuenteTareaFallida;
	
	public Color colorCompleta;
	public Color colorFallida;
	
	void Start() {
		this.botonPausa = GameObject.Find ("BotonPause").GetComponent<Button>();
		
		this.FuenteTareaInincial = new GUIStyle();
		this.FuenteTareaInincial.font = fuente;
		this.FuenteTareaInincial.normal.textColor = Color.black;
		this.FuenteTareaInincial.fontSize = 40;
		
		this.FuenteTareaCompleta = new GUIStyle();
		this.FuenteTareaCompleta.font = fuente;
		this.FuenteTareaCompleta.normal.textColor = colorCompleta;
		this.FuenteTareaCompleta.fontSize = 40;
		
		this.FuenteTareaFallida = new GUIStyle();
		this.FuenteTareaFallida.font = fuente;
		this.FuenteTareaFallida.normal.textColor = colorFallida;
		this.FuenteTareaFallida.fontSize = 40;
	}
	
	void OnGUI() {
		if (paused && !agenda && !salir) {
			GUI.DrawTexture (new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), fondo);
			
			if (GUI.Button (new Rect (Screen.width / 3.4f, Screen.height / 2.63f, 200, 150), boton1, "")) {
				this.paused = this.pausar ();
			}
			
			if (GUI.Button (new Rect (Screen.width / 2.25f, Screen.height / 2.63f, 200, 150), boton2, "")) {
				this.agenda = true;
			}
			
			if (GUI.Button (new Rect (Screen.width / 1.7f, Screen.height / 2.63f, 200, 150), boton3, "")) {
				this.salir = true;
			}
			
			if (Input.GetKeyDown (KeyCode.Escape)) {
				this.paused = this.pausar ();
			}
		}
		
		else if (agenda) {
			GUI.DrawTexture (new Rect (Screen.width/6, 0, Screen.width/1.45f, Screen.height), fondo);
			this.pintarTareasAgenda();
		}
		
		else if (salir) {
			GUI.DrawTexture (new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), fondo);
			this.pintarConfirmacionSalir();
		}
	}
	
	public bool pausar() {
		if(Time.timeScale == 0f) {
			Time.timeScale = 1f;
			this.botonPausa.interactable = true;
			
			if (GameObject.Find("BotonSiguienteEscena") != null) {
				if (VariablesGenerales.Instance.getBotonSiguienteEscenaActivo())
					GameObject.Find("BotonSiguienteEscena").GetComponent<Button>().interactable = true;
			}
							
			return false;
		}
		
		else {
			Time.timeScale = 0f;
			this.botonPausa.interactable = false;
			
			if (GameObject.Find("BotonSiguienteEscena") != null)
				GameObject.Find("BotonSiguienteEscena").GetComponent<Button>().interactable = false;
			
			return true ;    
		}
	}
	
	private void pintarTareasAgenda() {
		controladorEscena control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();
		int totalTareas = control.getTotalTareas ();
		int alturaTarea = 0;
		
		Texture checkboxActual = this.checkDesactivado;
		GUIStyle estiloActual = this.FuenteTareaInincial;
		
		for (int i=0; i<totalTareas; i++) {
			string tareaActual = control.getTarea(i);
			
			if (control.getEstadoTarea(i) == "inicial") {
				checkboxActual = this.checkDesactivado;
				estiloActual = this.FuenteTareaInincial;
			}
			
			else if (control.getEstadoTarea(i) == "completa") {
				checkboxActual = this.checkTareaCompleta;
				estiloActual = this.FuenteTareaCompleta;
			}
			
			else { //Fallida
				checkboxActual = this.checkTareaFallida;
				estiloActual = this.FuenteTareaFallida;
			}
			
			alturaTarea += 65;
			GUI.DrawTexture (new Rect (Screen.width/4.4f, alturaTarea, 30, 30), checkboxActual);
			GUI.Label (new Rect (Screen.width/3.7f, alturaTarea, 1, 1), tareaActual, estiloActual);
		}
		
		if ((GUI.Button (new Rect (Screen.width/1.35f, Screen.height/1.35f, 150, 100), boton1, "")) || (Input.GetKeyDown (KeyCode.Escape))) {
			this.agenda = false;
		}
	}
	
	private void pintarConfirmacionSalir() {
		GUI.Label (new Rect (Screen.width/2.25f, Screen.height / 3.3f, Screen.width / 2, Screen.height / 2), "¿Seguro?", this.FuenteTareaInincial);//, estiloActual);
		
		if (GUI.Button (new Rect (Screen.width / 2.9f, Screen.height / 2.63f, 200, 150), boton4, "")) {
			PixelCrushers.DialogueSystem.DialogueManager.ResetDatabase (PixelCrushers.DialogueSystem.DatabaseResetOptions.RevertToDefault);
			if (VariableJuegoPasado.Instance.getJuegoPasado())
				GameObject.Find ("Loader").GetComponent<FadeInLevelLoader>().LoadLevel("MenuPrincipal2");
			
			else
				GameObject.Find ("Loader").GetComponent<FadeInLevelLoader>().LoadLevel("MenuPrincipal1");
			
			this.paused = this.pausar ();
		}
		
		if ((GUI.Button (new Rect (Screen.width / 1.85f, Screen.height / 2.63f, 200, 150), boton5, "")) || (Input.GetKeyDown (KeyCode.Escape))) {
			this.salir = false;
		}
	}
	
	public void salirMenu() {
		this.paused = this.pausar ();
	}
}