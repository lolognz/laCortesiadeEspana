using UnityEngine;
using System.Collections;

public class GestorMensajesDialogue : MonoBehaviour {
	private PixelCrushers.DialogueSystem.Usable zorrilla;
	private PixelCrushers.DialogueSystem.Usable lucrecia;
	private PixelCrushers.DialogueSystem.Usable claudio;
	private PixelCrushers.DialogueSystem.Usable marcelo;
	private PixelCrushers.DialogueSystem.Usable leonarda;
	// Use this for initialization
	void Start () {
		try{
			this.zorrilla = GameObject.Find ("Zorrilla").GetComponent<PixelCrushers.DialogueSystem.Usable>();
		}catch{}
		try{
			this.lucrecia = GameObject.Find ("Lucrecia").GetComponent<PixelCrushers.DialogueSystem.Usable>();
		}catch{}
		try{
			this.claudio = GameObject.Find ("Claudio").GetComponent<PixelCrushers.DialogueSystem.Usable>();
		}catch{}
		try{
			this.leonarda = GameObject.Find ("Leonarda").GetComponent<PixelCrushers.DialogueSystem.Usable>();
		}catch{}
		try{
			this.marcelo = GameObject.Find ("Marcelo").GetComponent<PixelCrushers.DialogueSystem.Usable>();
		}catch{}
	}
	
	public void deshabilitaUsableEscena1(){
		this.zorrilla.overrideName = " ";
		this.zorrilla.overrideUseMessage = " ";
		this.lucrecia.overrideName = " ";
		this.lucrecia.overrideUseMessage = " ";
	}	

	public void habilitaUsableEscena1(){
		this.zorrilla.overrideName = "Zorrilla";
		this.zorrilla.overrideUseMessage = "Pulse encima para empezar conversacion";
		this.lucrecia.overrideName = "Lucrecia";
		this.lucrecia.overrideUseMessage = "Pulse encima para empezar conversacion";	
	}
	public void deshabilitaUsableEscena4(){
		this.zorrilla.overrideName = " ";
		this.zorrilla.overrideUseMessage = " ";
		this.lucrecia.overrideName = " ";
		this.lucrecia.overrideUseMessage = " ";
		this.leonarda.overrideName = " ";
		this.leonarda.overrideUseMessage = " ";
		this.claudio.overrideName = " ";
		this.claudio.overrideUseMessage = " ";
		this.marcelo.overrideName = " ";
		this.marcelo.overrideUseMessage = " ";
	}	
	
	public void habilitaUsableEscena4(){
		this.zorrilla.overrideName = "Zorrilla";
		this.zorrilla.overrideUseMessage = "Pulse encima para empezar conversacion";
		this.lucrecia.overrideName = "Lucrecia";
		this.lucrecia.overrideUseMessage = "Pulse encima para empezar conversacion";
		this.leonarda.overrideName = "Leonarda";
		this.leonarda.overrideUseMessage = "Pulse encima para empezar conversacion";
		this.claudio.overrideName = "Claudio";
		this.claudio.overrideUseMessage = "Pulse encima para empezar conversacion";	
		this.marcelo.overrideName = "Marcelo";
		this.marcelo.overrideUseMessage = "Pulse encima para empezar conversacion";
	}
}
