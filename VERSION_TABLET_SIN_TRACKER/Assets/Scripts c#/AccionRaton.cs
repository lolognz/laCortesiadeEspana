using UnityEngine;
using System.Collections;

public class AccionRaton : MonoBehaviour {

	private AudioSource audio;
	private Animator anim;

	void Start () {
		this.audio = this.gameObject.GetComponent<AudioSource> ();
		this.anim = this.gameObject.GetComponent<Animator> ();
	}

	void OnMouseDown() {
		if (!this.audio.isPlaying)
			this.audio.Play ();

		this.anim.enabled = false;
		StartCoroutine (waitFor ());
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds (1f);
		this.anim.enabled = true;
	}
}