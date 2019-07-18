using UnityEngine;
using System.Collections;

public class MovimientoEspada : MonoBehaviour {
	public Transform puntaEspada;
	public int velocidad = 2000;
	private Vector3 target;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
		}
		if (target.x - 0.3 > puntaEspada.position.x) {
				if (this.transform.eulerAngles.z > 10)
					this.transform.Rotate (Vector3.back * Time.deltaTime * velocidad);
		} else if (target.x + 0.3 < puntaEspada.position.x) {
				if (this.transform.eulerAngles.z < 170)
					this.transform.Rotate (Vector3.forward * Time.deltaTime * velocidad);
			}
		
		//Debug.Log("Posicion " + this.transform.rotation.z);
	}
}
