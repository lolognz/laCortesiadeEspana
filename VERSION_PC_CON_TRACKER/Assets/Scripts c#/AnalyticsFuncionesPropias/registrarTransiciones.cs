using UnityEngine;
using System.Collections;

public class registrarTransiciones : MonoBehaviour {

	public int numTransicion = 0;

	void Start () {
		if (this.numTransicion == 1) {
			if (Tracker.T () != null)
				Tracker.T ().Zone ("Transicion Barcelona");
		}

		else if (this.numTransicion == 2) {
			if (Tracker.T () != null)
				Tracker.T ().Zone ("Transicion Orgaz");
		}

		else if (this.numTransicion == 3) {
			if (Tracker.T () != null)
				Tracker.T ().Zone ("Transicion Toledo");
		}

		if (Tracker.T () != null)
			Tracker.T ().RequestFlush ();
	}
}