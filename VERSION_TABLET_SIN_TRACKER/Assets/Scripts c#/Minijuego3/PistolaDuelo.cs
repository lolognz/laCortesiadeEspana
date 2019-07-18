using UnityEngine;
using System.Collections;

public class PistolaDuelo : MonoBehaviour {
	public static int PulsacionesNecesarias = 24;
	private static int balas;
	// Use this for initialization
	void Start () {
		balas = 0;
	}

	void Update(){
		//Debug.Log("" + balas.ToString());
	}
	public static void SumaBala(){
		balas = balas +1;
	}
	public static void resetBalas(){
		balas = 0;
	}
	public static int getBalas(){
		return balas;
	}
}
