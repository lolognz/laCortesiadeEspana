using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands {
	
	public class SequencerCommandDebugQuest : MonoBehaviour {

		// Use this for initialization
		void Start () {
			string state = DialogueLua.GetQuestField("Repartir_Habitaciones", "State").AsString;
			Debug.Log (state);
			Debug.Log ("AQUIIIIIIIIIIIIIIIIIII");
		}
		
	}
}
