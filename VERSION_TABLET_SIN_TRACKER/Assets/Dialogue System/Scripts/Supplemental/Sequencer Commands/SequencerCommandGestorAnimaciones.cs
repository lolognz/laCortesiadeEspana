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
	public class SequencerCommandGestorAnimaciones : SequencerCommand {
		private Animator anim;
		public void Start() {
			string nombrePersonaje = GetParameter(0);
			string nombreAnimacion = GetParameter(1);
			bool estadoAnimacion = GetParameterAsBool(2);
			try{
				GameObject personaje = GameObject.Find (nombrePersonaje);
				this.anim = personaje.GetComponent<Animator> ();
				this.anim.SetBool (nombreAnimacion, estadoAnimacion);
			}catch{
			}
			try{
				if (nombreAnimacion == "hablando" && estadoAnimacion){
					if (nombrePersonaje == "Zorrilla" || nombrePersonaje == "Zorrilla.")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (107, 96, 246, 255);
					else if (nombrePersonaje == "Lucrecia" || nombrePersonaje == "Lucrecia." || nombrePersonaje == "Dama en apuros")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (255, 174, 0, 255);
					else if (nombrePersonaje == "DonJuan")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (43, 154, 48, 255);
					else if (nombrePersonaje == "Marcelo")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (137, 86, 58, 255);
					else if (nombrePersonaje == "Leonarda")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (182, 182, 182, 255);
					else if (nombrePersonaje == "Claudio" || nombrePersonaje == "Vándalo")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (130, 63, 165, 255);
					else if (nombrePersonaje == "Mendigo")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (226, 229, 0, 255);
					else if (nombrePersonaje == "Mesonero Joven")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (255, 219, 103 ,255);
					else if (nombrePersonaje == "Tendero Viejo")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (128, 0, 0, 255);
					else if (nombrePersonaje == "Cliente1")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (102, 255, 0, 255);
					else if (nombrePersonaje == "Cliente2")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32  (0, 204, 255, 255);
					else if (nombrePersonaje == "Campesino Julio")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (255, 204, 0, 255);
					else if (nombrePersonaje == "Campesino Ernesto")
						GameObject.Find("Default Dialogue UI").GetComponent<PixelCrushers.DialogueSystem.UnityGUI.UnityDialogueUI> ().guiRoot.guiSkin.label.normal.textColor = new Color32 (0, 0, 128, 255);
					}
				}catch{}
			Stop();
		}
	}
}

