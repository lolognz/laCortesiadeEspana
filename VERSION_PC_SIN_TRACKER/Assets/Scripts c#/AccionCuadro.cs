using UnityEngine;
using System.Collections;

public class AccionCuadro : MonoBehaviour {

	private Animator anim;
	private AudioSource audio;
	
	void Start () {
		this.anim = this.GetComponent<Animator> ();
		this.audio = this.gameObject.GetComponent<AudioSource> ();
	}
	
	void OnMouseDown() {
		this.anim.Play ("Parpadeo");
		this.audio.Play ();
	}
}