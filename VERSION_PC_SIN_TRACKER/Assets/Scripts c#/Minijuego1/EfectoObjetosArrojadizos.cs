using UnityEngine;
using System.Collections;

public class EfectoObjetosArrojadizos : MonoBehaviour {
	private float speed = 0.02f;
	private bool efecto = false;

	private controladorMinijuego1 control;
	private AudioSource audio;
	private int i ;
	void Start() {
		this.control = GameObject.Find ("ControladorEscena").GetComponent<controladorMinijuego1> ();
		this.audio = GameObject.Find ("SonidoTocarObjeto").GetComponent<AudioSource> ();
		this.i = Random.Range (0, 2);
	}

	void FixedUpdate () {
		if (!efecto) {
			this.transform.localScale = new Vector3 (transform.localScale.x + speed, transform.localScale.y + speed, transform.localScale.z);
			if (this.transform.localScale.x >= 2) {
				Destroy (this.gameObject);
				this.control.perderVda ();
			}
		}
		
		else {
			//this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(this.transform.position.x,this.transform.position.y-200,this.transform.position.y), speed * Time.deltaTime);
			//this.transform.rotation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z + speed*15, transform.rotation.w);
			
			this.transform.Rotate (Vector3.back * Time.deltaTime * 1000);
			
			if (this.i == 1) 
				this.transform.position = new Vector3 (transform.position.x + speed*25, transform.position.y + speed*25, transform.position.z);
			else 
				this.transform.position = new Vector3 (transform.position.x - speed*25, transform.position.y + speed*25, transform.position.z);
		}
	}

	void OnMouseDown() {
		this.control.aumentarToques ();
		if (!this.efecto)
			this.audio.Play ();
		
		this.efecto = true;
		StartCoroutine (WaitFor ());
	}

	IEnumerator WaitFor() {
		yield return new WaitForSeconds(2);
		Destroy (this.gameObject);
	}
}