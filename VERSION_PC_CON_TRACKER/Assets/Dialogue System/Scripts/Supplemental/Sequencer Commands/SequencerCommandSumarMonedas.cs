using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands {
	
	/// <summary>
	/// This script implements the sequencer command LoadLevel(levelName).
	/// Before loading the level, it calls PersistentDataManager.Record() to
	/// tell objects in the current level to record their persistent data first,
	/// and then it calls LevelWillBeUnloaded() to tell the objects to ignore
	/// the upcoming OnDestroy() if they have OnDestroy() handlers.
	/// 
	/// If the Dialogue Manager has a LevelManager script, this command will use it.
	/// </summary>
	public class SequencerCommandSumarMonedas : SequencerCommand {
		
		public void Start() {
			int valorMonedas = GetParameterAsInt(0);
			//variablesGlobales.monedas += valorMonedas;
			GameObject.Find ("HUD").GetComponent<variablesHUD> ().aumentaDinero (valorMonedas);
			Stop();
		}
	}
}
