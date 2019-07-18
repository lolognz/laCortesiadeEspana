using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands {

	public class SequencerCommandGestorFinales : SequencerCommand {
		private Animator anim;
		public void Start() {
			string final = GetParameter(0);
			VariablesGenerales.Instance.setFinal (final);
			GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel ("FinalJuego");
		}
	}
}