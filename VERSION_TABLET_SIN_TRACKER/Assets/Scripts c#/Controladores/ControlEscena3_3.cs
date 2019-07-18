using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlEscena3_3 : MonoBehaviour {

	private controladorEscena control;
	private Button siguiente;

	void Start () {
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ();
		if (VariablesGenerales.Instance.getTareaEspecialClientes ())
			this.control.marcarTareaCompleta (0);
		else
			this.control.marcarTareaFallida (0);
		
		this.control.marcarTareaCompleta (1);
		this.control.marcarTareaCompleta (2);
		this.control.marcarTareaCompleta (3);
		
		if (VariablesGenerales.Instance.getTareaEspecialDescubrirRuidos ())
			this.control.marcarTareaCompleta (4);
		else
			this.control.marcarTareaFallida (4);

		if (VariablesGenerales.Instance.getTareaEspecialRobarPosadero ())
			this.control.marcarTareaCompleta (5);
		else
			this.control.marcarTareaFallida (5);

		this.control.marcarTareaCompleta (6, true, false);
		VariablesGenerales.Instance.aumentarTareasCompletas (); //Aumentamos una tarea completa por la salida de la posada.

		this.siguiente = GameObject.Find ("BotonSiguienteEscena").GetComponent<Button>();
		this.siguiente.interactable = true;
		GameObject.Find ("BotonSiguienteEscena").GetComponent<EfectoParpadeo> ().enabled = true;
	}

	public void habilitaEscenaSiguiente(){
		this.siguiente.interactable = true;
	}

	public void desHabilitaEscenaSiguiente(){
		this.siguiente.interactable = false;
	}
}