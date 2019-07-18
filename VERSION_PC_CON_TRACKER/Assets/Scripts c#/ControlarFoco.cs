using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlarFoco : MonoBehaviour {

	public string nombreFoco;
	public string escenaAccion;

	private GameObject foco;
	private SpriteRenderer sr = new SpriteRenderer();
	private Animator anim;

	private AudioSource audio;

	void Start () {
		this.foco = GameObject.Find (this.nombreFoco);
		this.sr = foco.gameObject.GetComponent<SpriteRenderer> ();
		this.sr.enabled = false;
		this.anim = this.gameObject.GetComponent<Animator> ();
		this.audio = GameObject.Find ("AplausosSonido").GetComponent<AudioSource> ();
	}

	void OnMouseEnter() {
		this.sr.enabled = true;
		this.anim.SetBool ("Esperando", false);
		this.audio.Play ();
	}
	
	void OnMouseExit() {
		this.sr.enabled = false;
		this.anim.SetBool ("Esperando", true);
		this.audio.Stop ();
	}

	void OnMouseDown() {
		if (this.escenaAccion != "") {
			if (this.escenaAccion == "Salir")
				Application.Quit();

			else
				GameObject.Find("Loader").GetComponent<FadeInLevelLoader>().LoadLevel(this.escenaAccion);
		}
	}
}