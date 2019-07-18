using UnityEngine;
using System.Collections;

public class SaltarEscenaDebug : MonoBehaviour {

	public void saltarEscena(string s){
		Application.LoadLevel (s);
	}
}
