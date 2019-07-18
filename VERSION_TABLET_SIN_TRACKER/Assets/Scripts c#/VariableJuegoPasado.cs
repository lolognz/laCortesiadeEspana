using UnityEngine;
using System.Collections;

public class VariableJuegoPasado : MonoBehaviour {
	
	private static VariableJuegoPasado instance;
	private static bool juegosPasado;
	
	public static VariableJuegoPasado Instance {
		get {
			if (instance == null) {
				GameObject variableJuegoPasadoObject = new GameObject("VariableJuegoPasadoObject");
				DontDestroyOnLoad(variableJuegoPasadoObject);
				juegosPasado = false;
				instance = variableJuegoPasadoObject.AddComponent<VariableJuegoPasado>();
			}
			
			return instance;
		}
	}
	
	public bool getJuegoPasado() {
		return juegosPasado;
	}
	
	public void setJuegoPasado() {
		juegosPasado = true;
	}
}