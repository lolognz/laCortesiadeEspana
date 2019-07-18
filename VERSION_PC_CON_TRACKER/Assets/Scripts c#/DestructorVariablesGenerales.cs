using UnityEngine;
using System.Collections;

public class DestructorVariablesGenerales : MonoBehaviour {

	void Start () {
		if (VariablesGenerales.Instance != null) {
			Debug.Log("Se destruyen las Variables Generales");
			Destroy(VariablesGenerales.Instance);
		}
	}
}