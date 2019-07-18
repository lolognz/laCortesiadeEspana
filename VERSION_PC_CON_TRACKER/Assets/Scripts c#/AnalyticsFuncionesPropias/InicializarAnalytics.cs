using UnityEngine;
using System.Collections;

public class InicializarAnalytics : MonoBehaviour {
	
	void Start () {
		if (VariableCodigoUsuario.Instance.getCodigoUsuario () != -7) {
			Tracker tracker = Tracker.T ();
			tracker.Var ("Codigo Usuario", VariableCodigoUsuario.Instance.getCodigoUsuario ());
			tracker.Screen("Menu Principal");
			tracker.RequestFlush ();
		}
	}
}