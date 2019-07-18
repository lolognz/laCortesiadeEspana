using UnityEngine;
using System.Collections;


public class controladorEscena : MonoBehaviour {

	public string fichero;
	public string siguienteEscena;

	private string[] tareas;
	private string[] estadosTareas; //TRES ESTADOS: INICIAL, COMPLETA Y FALLIDA.
	private string contenidoFichero;

	void Start () {
		//Por seguridad para evitar nulls. Si no se pone siguienteEscena, se pone por defecto el menu principal.
		if (this.siguienteEscena == "") {
			this.siguienteEscena = "MenuPrincipal1";
		}

		TextAsset archivo = Resources.Load(this.fichero) as TextAsset;
		this.contenidoFichero = archivo.text;
		this.tareas = this.contenidoFichero.Split ('\n');

		this.estadosTareas = new string[this.tareas.Length];
		this.inicializarEstados ();
	}

	public string[] getListaTareas() {
		return this.tareas;
	}

	public string[] getEstadosTareas() {
		return this.estadosTareas;
	}

	public int getTotalTareas() {
		return this.tareas.Length;
	}

	public string getTarea(int num) {
		return this.tareas [num];
	}

	public string getEstadoTarea(int num) {
		return this.estadosTareas [num];
	}

	public bool esTareaCompleta(int num) {
		return this.estadosTareas[num] == "completa";
	}

	public bool esTareaFallida(int num) {
		return this.estadosTareas[num] == "fallida";
	}

	// La variable primera es para que contabilice como completa si es true y opcional que aumente la variable opcional si es true.
	public void marcarTareaCompleta(int num, bool primera = false, bool opcional = false) { //Por defecto no es opcional ni primera.
		this.estadosTareas [num] = "completa";
		if (primera) {
			if (opcional)
				VariablesGenerales.Instance.aumentarTareasOpcionalesCompletas ();
		
			VariablesGenerales.Instance.aumentarTareasCompletas ();
		}
	}

	public void marcarTareaFallida(int num) {
		this.estadosTareas [num] = "fallida";
	}

	private void inicializarEstados() {
		for (int i=0; i<this.tareas.Length; i++)
			this.estadosTareas [i] = "inicial";
	}

	public void cargarSiguienteEscena() {
		Application.LoadLevel (this.siguienteEscena);
	}
}