using UnityEngine;
using System.Collections;

public class SequencerCommandIniciarJuego : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PixelCrushers.DialogueSystem.DialogueLua.SetVariable ("Dinero", 20);
	}
}
