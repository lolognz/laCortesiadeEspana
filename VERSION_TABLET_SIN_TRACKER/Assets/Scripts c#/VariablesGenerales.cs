using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class VariablesGenerales : MonoBehaviour {
	
	private static VariablesGenerales instance;
	
	private static int dinero;
	private static int cortesia;
	private static bool onConversation;
	
	//Variables especificas
	private static bool cofreAbierto;
	private static string tipoFinal;
	private static bool donJuanPersigue;
	private static bool mensajeMarceloInterrumpeBoda;
	private static int ratonesEncontrados;
	private static bool easterEggRaton;
	private static string nombreRaton;	
	
	//Tareas
	private static int TAREAS_BOSQUE = 5;
	private static int TAREAS_PUERTO = 4;
	private static int TAREAS_POSADA = 8;
	private static int TAREAS_TOLEDO = 5;
	private static int TAREAS_TOTALES = TAREAS_BOSQUE + TAREAS_PUERTO + TAREAS_POSADA + TAREAS_TOLEDO;
	private static int tareasCompletas;
	private static int tareasOpcionalesCompletas;

	//Siguiente Escena Booleano
	private static bool botonSiguienteEscenaActivo;

	//Tareas especiales, necesarias para consultar en otras escenas
	//Escena 1
	private static bool tareaEspecialBosque; //Tarea perseguir al malhechor.
	
	//Escena 2
	private static bool tareaEspecialMendigo; //Tarea dar de comer al mendigo.
	private static bool tareaEspecialComprarDuenas; //Tarea comprar dueñas.
	
	//Escena 3
	private static bool tareaEspecialClientes; //Tarea de hablar con ambos clientes.
	private static bool tareaEspecialDescubrirRuidos; //Tarea de ganar minijuego2.
	private static bool tareaEspecialRobarPosadero; //Tarea de robar la bolsa al posadero.
	
	//Escena 4
	private static bool tareaEspecialBatirseDuelo; //Tarea de ganar el duelo con Marcelo.
	private static bool apareceClaudio;

	public static VariablesGenerales Instance {
		get {
			if (instance == null) {
				GameObject variablesGeneralesObject = new GameObject("VariablesGeneralesObject");
				DontDestroyOnLoad(variablesGeneralesObject);
				dinero = 20;
				PixelCrushers.DialogueSystem.DialogueLua.SetVariable ("Dinero", dinero);
				cortesia = 50;
				tipoFinal = "";
				tareasCompletas = 0;
				tareasOpcionalesCompletas = 0;
				cofreAbierto = false;
				tareaEspecialBosque = false;
				tareaEspecialClientes = false;
				tareaEspecialDescubrirRuidos = false;
				tareaEspecialRobarPosadero = false;
				tareaEspecialBatirseDuelo = false;
				tareaEspecialMendigo = false;
				tareaEspecialComprarDuenas = false;
				donJuanPersigue = true;
				onConversation = false;
				apareceClaudio = false;
				mensajeMarceloInterrumpeBoda = false;
				ratonesEncontrados = 0;
				easterEggRaton = false;
				nombreRaton = "";
				botonSiguienteEscenaActivo = false;
				instance = variablesGeneralesObject.AddComponent<VariablesGenerales>();
				Debug.Log("Se ha creado una instancia de Variables Generales.");
			}
			
			return instance;
		}
	}
	
	public void aumentaDinero(int cantidad) {
		dinero += cantidad;
		PixelCrushers.DialogueSystem.DialogueLua.SetVariable ("Dinero", dinero);
	}
	
	public int getDineroActual() {
		return dinero;
	}
	
	public bool getOnConversation() {
		return onConversation;
	}
	
	public void setOnConversation(bool v) {
		onConversation = v;
	}	

	public bool getApareceClaudio() {
		return apareceClaudio;
	}
	
	public void setApareceClaudio(bool v) {
		apareceClaudio = v;
	}	
	public void aumentaCortesia(int cantidad) {
		cortesia += cantidad;
		
		if (cortesia > 100)
			cortesia = 100;
		
		else if (cortesia < 0)
			cortesia = 0;

		PixelCrushers.DialogueSystem.DialogueLua.SetVariable ("Cortesia", cortesia);
	}
	
	public int getCortesiaActual() {
		return cortesia;
	}
	
	public bool getCofreAbierto() {
		return cofreAbierto;
	}
	
	public void setCofreAbierto() {
		cofreAbierto = true;
		PixelCrushers.DialogueSystem.DialogueLua.SetVariable ("Tutorial", true);
	}
	
	public string getFinal() {
		return tipoFinal;
	}
	
	public void setFinal(string final) {
		tipoFinal = final;
	}
	
	public void aumentarTareasCompletas() {
		tareasCompletas ++;
	}
	
	public int getTareasCompletas() {
		return tareasCompletas;
	}
	
	public void aumentarTareasOpcionalesCompletas() {
		tareasOpcionalesCompletas ++;
	}
	
	public int getTareasOpcionalesCompletas() {
		return tareasOpcionalesCompletas;
	}
	
	public void completarTareaEspecialBosque() {
		tareaEspecialBosque = true;
	}
	
	public bool getTareaEspecialBosque() {
		return tareaEspecialBosque;
	}
	
	public void completarTareaEspecialMendigo() {
		tareaEspecialMendigo = true;
	}
	
	public bool getTareaEspecialMendigo() {
		return tareaEspecialMendigo;
	}
	
	public void completarTareaEspecialComprarDuenas() {
		tareaEspecialComprarDuenas = true;
	}
	
	public bool getTareaEspecialComprarDuenas() {
		return tareaEspecialComprarDuenas;
	}
	
	public void completarTareaEspecialClientes() {
		tareaEspecialClientes = true;
	}
	
	public bool getTareaEspecialClientes() {
		return tareaEspecialClientes;
	}
	
	public void completarTareaEspecialDescubrirRuidos() {
		tareaEspecialDescubrirRuidos = true;
	}
	
	public bool getTareaEspecialDescubrirRuidos() {
		return tareaEspecialDescubrirRuidos;
	}
	
	public void completarTareaEspecialRobarPosadero() {
		tareaEspecialRobarPosadero = true;
		PixelCrushers.DialogueSystem.DialogueLua.SetVariable ("RobarPosadero", true);
	}
	
	public bool getTareaEspecialRobarPosadero() {
		return tareaEspecialRobarPosadero;
	}
	
	public bool getTareaEspecialBatirseDuelo() {
		return tareaEspecialBatirseDuelo;
	}
	
	public void completarTareaEspecialBatirseDuelo() {
		tareaEspecialBatirseDuelo = true;
	}
	
	public bool donJuanPersigueClaudio() {
		return donJuanPersigue;
	}
	
	public void setZorrillaPersigueClaudio() {
		donJuanPersigue = false;
	}
	
	public bool getMensajeMarceloInterrumpeBoda() {
		return mensajeMarceloInterrumpeBoda;
	}
	
	public void setMensajeMarceloInterrumpeBoda() {
		mensajeMarceloInterrumpeBoda = true;
	}
	
	public int getTotalTareasBosque() {
		return TAREAS_BOSQUE;
	}
	
	public int getTotalTareasPuerto() {
		return TAREAS_PUERTO;
	}
	
	public int getTotalTareasPosada() {
		return TAREAS_POSADA;
	}
	
	public int getTotalTareasToledo() {
		return TAREAS_TOLEDO;
	}
	
	public int getTareasTotales() {
		return TAREAS_TOTALES;
	}
	
	//EasterEgg Raton
	public int getRatonesEncontrados() {
		return ratonesEncontrados;
	}
	
	public void ratonEncontrado() {
		ratonesEncontrados++;
	}
	
	public bool getEasterEggRaton() {
		return easterEggRaton;
	}
	
	public void activarEasterEggRaton() {
		easterEggRaton = true;
	}

	public string getNombreRaton() {
		return nombreRaton;
	}
	
	public void darNombreRaton(string nombre) {
		nombreRaton = nombre;
	}

	public bool getBotonSiguienteEscenaActivo() {
		return botonSiguienteEscenaActivo;
	}

	public void setBotonSiguienteEscenaActivo(bool b) {
		botonSiguienteEscenaActivo = b;
	}
}