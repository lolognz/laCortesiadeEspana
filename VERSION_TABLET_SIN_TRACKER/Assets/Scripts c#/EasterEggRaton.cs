using UnityEngine;
using System.Collections;

public class EasterEggRaton : MonoBehaviour {

	void OnMouseDown() {
		this.gameObject.GetComponent<AudioSource> ().Play ();
		GameObject.Find("Loader").GetComponent<FadeInLevelLoader>().LoadLevel("EscenaEasterEgg");
	}
}