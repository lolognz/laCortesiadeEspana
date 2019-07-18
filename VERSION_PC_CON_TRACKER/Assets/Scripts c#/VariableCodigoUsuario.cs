using UnityEngine;
using System.Collections;

public class VariableCodigoUsuario : MonoBehaviour {

	private static VariableCodigoUsuario instance;

	private static int codigoUsuario;
	private static bool juegosPasado;

	public static VariableCodigoUsuario Instance {
		get {
			if (instance == null) {
				GameObject variableCodigoUsuarioObject = new GameObject("VariableCodigoUsuarioObject");
				DontDestroyOnLoad(variableCodigoUsuarioObject);
				codigoUsuario = -1;
				juegosPasado = false;
				instance = variableCodigoUsuarioObject.AddComponent<VariableCodigoUsuario>();
				Debug.Log("Se ha creado una instancia de Variables Codigo Usuario.");
			}
			
			return instance;
		}
	}
	
	public int getCodigoUsuario() {
		return codigoUsuario;
	}

	public void setCodigoUsuario(int n) {
		codigoUsuario = n;
	}

	public bool getJuegoPasado() {
		return juegosPasado;
	}
	
	public void setJuegoPasado() {
		juegosPasado = true;
	}
}