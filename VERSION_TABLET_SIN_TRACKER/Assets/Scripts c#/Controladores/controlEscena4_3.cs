using UnityEngine;
using System.Collections;

public class controlEscena4_3 : MonoBehaviour {

	private controladorEscena control;
	
	void Start () {
		this.control = this.gameObject.GetComponent<controladorEscena> ();
		this.control.marcarTareaCompleta (0);	//Completada en la escena 4.
		this.control.marcarTareaCompleta (1);	//Completada en la escena 4.
		this.control.marcarTareaCompleta (2);	//Completada en la escena 4.2.
	}
}