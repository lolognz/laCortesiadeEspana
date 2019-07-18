using UnityEngine;
using System.Collections;

public class controlEscena4_4 : MonoBehaviour {

	private controladorEscena control;
	
	void Start () {
		this.control = this.gameObject.GetComponent<controladorEscena> ();
		this.control.marcarTareaCompleta (0);	//Completada en la escena 4.
		this.control.marcarTareaCompleta (1);	//Completada en la escena 4.
		this.control.marcarTareaCompleta (2);	//Completada en la escena 4.2.

		if (VariablesGenerales.Instance.getTareaEspecialBatirseDuelo())
			this.control.marcarTareaCompleta (3, true, true);	//Completada en el minijuego Duelo.
		else
			this.control.marcarTareaFallida (3);	//No ha habido duelo
	}
}