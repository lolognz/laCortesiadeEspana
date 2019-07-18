using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands {
	
	public class SequencerCommandBotonCambioEscena : SequencerCommand {
		
		public void Start(){
			bool boolStart = GetParameterAsBool(0);
			VariablesGenerales.Instance.setBotonSiguienteEscenaActivo (boolStart);
		}
	}
}
