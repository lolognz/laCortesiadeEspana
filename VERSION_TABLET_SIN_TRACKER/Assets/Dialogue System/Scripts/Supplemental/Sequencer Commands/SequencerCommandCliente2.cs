using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands {
	
	public class SequencerCommandCliente2 : MonoBehaviour {
		
		private ControlEscena3 control;
		// Use this for initialization
		void Start () {
			control = GameObject.Find ("ControladorEscena").GetComponent<ControlEscena3> ();
			control.hablarConCliente2 ();
		}
		
	}
}
