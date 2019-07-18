using UnityEngine;
using System.Collections;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class CallarPersonajes1 : MonoBehaviour {
	private Animator anim1;
	private Animator anim2;
	private Animator anim3;
	private Animator anim4;
	private Animator anim5;
	private Animator anim6;
	private Animator anim7;
	private Animator anim8;
	private Animator anim9;
	private Animator anim10;
	private Animator anim11;
	private Animator anim12;
	private Animator anim13;
	private Animator anim14;
	private Animator anim15;
	private Animator anim16;
	private float tiempo = 1f;
	private bool para;
	// Use this for initialization
	void Start () {
		para = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		GameObject Speaker = GameObject.Find ("Speaker");
		AudioSource ASSpeaker = Speaker.GetComponent<AudioSource> ();

		if (!ASSpeaker.isPlaying) {
			try	{
				GameObject personaje1 = GameObject.Find ("Zorrilla");
				this.anim1 = personaje1.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje2 = GameObject.Find ("DonJuan");
				this.anim2 = personaje2.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje3 = GameObject.Find ("Vándalo");
				this.anim3 = personaje3.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje4 = GameObject.Find ("Dama en apuros");
				this.anim4 = personaje4.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje5 = GameObject.Find ("Zorrilla.");
				this.anim5 = personaje5.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje6 = GameObject.Find ("Lucrecia");
				this.anim6 = personaje6.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje7 = GameObject.Find ("Mendigo");
				this.anim7 = personaje7.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje8 = GameObject.Find ("Mesonero Joven");
				this.anim8 = personaje8.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje9 = GameObject.Find ("Tendero Viejo");
				this.anim9 = personaje9.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje10 = GameObject.Find ("Cliente1");
				this.anim10 = personaje10.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje11 = GameObject.Find ("Cliente2");
				this.anim11 = personaje11.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje12 = GameObject.Find ("Campesino Julio");
				this.anim12 = personaje12.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje13 = GameObject.Find ("Campesino Ernesto");
				this.anim13 = personaje13.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje14 = GameObject.Find ("Leonarda");
				this.anim14 = personaje14.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje15 = GameObject.Find ("Marcelo");
				this.anim15 = personaje15.GetComponent<Animator> ();
			}catch{}
			try	{
				GameObject personaje16 = GameObject.Find ("Claudio");
				this.anim16 = personaje16.GetComponent<Animator> ();
			}catch{}




			try	{
				this.anim1.SetBool ("hablando", false);
			}catch{}
			try	{
				this.anim2.SetBool ("hablando", false);
			}catch{}
			try	{
				this.anim3.SetBool ("hablando", false);
			}catch{}
			try	{
				this.anim4.SetBool ("hablando", false);
			}catch{}
			try	{
				this.anim5.SetBool ("hablando", false);
			}catch{}
			try	{
				this.anim6.SetBool ("hablando", false);
			}catch{}	
			try	{
				this.anim7.SetBool ("hablando", false);
			}catch{}	
			try	{
				this.anim8.SetBool ("hablando", false);
			}catch{}		
			try	{
				this.anim9.SetBool ("hablando", false);
			}catch{}			
			try	{
				this.anim10.SetBool ("hablando", false);
			}catch{}			
			try	{
				this.anim11.SetBool ("hablando", false);
			}catch{}			
			try	{
				this.anim12.SetBool ("hablando", false);
			}catch{}				
			try	{
				this.anim13.SetBool ("hablando", false);
			}catch{}				
			try	{
				this.anim14.SetBool ("hablando", false);
			}catch{}				
			try	{
				this.anim15.SetBool ("hablando", false);
			}catch{}					
			try	{
				this.anim16.SetBool ("hablando", false);
			}catch{}

			if (!VariablesGenerales.Instance.getOnConversation() && para){
				try{
					if (PixelCrushers.DialogueSystem.DialogueManager.IsConversationActive)	
						DialogueManager.Instance.SendMessage("OnConversationContinue");
				}catch{}
				para = false;
				Invoke ("cambiaPara", tiempo);
			}
		}
	}

	private void cambiaPara (){
		para = true;
	}
}

