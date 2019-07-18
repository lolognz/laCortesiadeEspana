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
	public class SequencerCommandSpeaker : SequencerCommand {
		
		public void Start() {
			string vozApaga = GetParameter(0);
			string vozEnciende = GetParameter(1);
			GameObject Speaker = GameObject.Find ("Speaker");
			//variablesGlobales.honor += valorHonor;
			AudioSource ASSpeaker = Speaker.GetComponent<AudioSource> ();
			if (!string.IsNullOrEmpty (vozApaga)) {
				AudioClip au = Resources.Load (vozApaga) as AudioClip;
				if (au != null){
					ASSpeaker.clip = au;
					ASSpeaker.Play ();
				}
			}

			if (!string.IsNullOrEmpty (vozEnciende)) {
				AudioClip au = Resources.Load (vozEnciende) as AudioClip;
				if (au != null){
					ASSpeaker.clip = au;
					ASSpeaker.Stop ();
				}
			}

			Stop();
		}
	}
}
