using UnityEngine;
using System.Collections;

public class BarraCarga : MonoBehaviour {

	void Start () {
		this.gameObject.transform.localScale = new Vector3 (transform.localScale.x, 0, transform.localScale.z);
	}

	void Update () {
		float multiplicador = (float)1.2 /PistolaDuelo.PulsacionesNecesarias ;
		float balas = (float)PistolaDuelo.getBalas () * multiplicador;
		this.gameObject.transform.localScale = new Vector3 (transform.localScale.x, balas, transform.localScale.z);
	}
}