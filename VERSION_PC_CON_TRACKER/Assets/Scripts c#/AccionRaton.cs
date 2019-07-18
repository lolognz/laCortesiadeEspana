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
		if (Tracker.T () != null) {
			Tracker.T ().Click(Input.mousePosition.x, Input.mousePosition.y, this.gameObject.name);
		}

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