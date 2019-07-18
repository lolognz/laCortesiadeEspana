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
	public class SequencerCommandMarcarTarea : SequencerCommand {
		
		public void Start() {
			bool bool2 = false;
			int tarea = 0;
			bool bool1 = false;
			try{
				tarea = GetParameterAsInt(0);
			}
			catch{Debug.Log("Error tarea");}
			try{
				 bool1 = GetParameterAsBool(1);
			}
			catch{Debug.Log("Error bool1");}
			try{
				bool2 = GetParameterAsBool(2);
			}
			catch{Debug.Log("Error bool2");}
			GameObject.Find ("ControladorEscena").GetComponent<controladorEscena> ().marcarTareaCompleta (tarea,bool1,bool2);
			Stop();
		}
	}
}
