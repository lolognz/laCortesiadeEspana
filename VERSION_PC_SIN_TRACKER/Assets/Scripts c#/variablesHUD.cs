using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class variablesHUD : MonoBehaviour {

	private Text imagenDinero;
	private establecerCortesia imgCortesia;

	private AudioSource[] audios;
	private AudioSource audioDinero;
	private AudioSource audioCortesia;
	public AudioClip audioGanarDinero;
	public AudioClip audioGanarCortesia;
	public AudioClip audioPerderCortesia;
	public AudioClip audioPerderDinero;
	
	private Image barraCotesia;
	private Text gananciaCortesia;

	private bool cambiarCortesia = false;
	private bool subirCortesia = true;
	private byte colorCortesia = 255;
	private float posicionGananciaY = 30;
	
	void Start () {
		this.imagenDinero = GameObject.Find ("CantidadDinero").GetComponent<Text> ();
		this.gananciaCortesia = GameObject.Find ("GananciaCortesia").GetComponent<Text> ();
		this.imgCortesia = GameObject.Find ("BarraHonor").GetComponent<establecerCortesia> ();

		this.barraCotesia = GameObject.Find ("BarraHonor").GetComponent<Image> ();

		this.audios = this.gameObject.GetComponents<AudioSource> ();
		this.audioDinero = this.audios [0];
		this.audioCortesia = this.audios [1];
		this.imagenDinero.text = VariablesGenerales.Instance.getDineroActual ().ToString();
		if (VariablesGenerales.Instance.getDineroActual () >= 50)
			this.imagenDinero.color = new Color32(0, 66, 6, 255);

		this.imgCortesia.setImagenCortesia (VariablesGenerales.Instance.getCortesiaActual ());
		this.gananciaCortesia.enabled = false;
	}

	void FixedUpdate() {
		if (this.cambiarCortesia) {
			if (this.colorCortesia >= 255)
				this.subirCortesia = false;
			
			if (this.colorCortesia <= 0)
				this.subirCortesia = true;
			
			if (this.subirCortesia)
				this.colorCortesia+=7;
			else
				this.colorCortesia-=7;

			this.barraCotesia.color = new Color32(255,255,255,this.colorCortesia);
			this.gananciaCortesia.transform.position = new Vector3(this.gananciaCortesia.transform.position.x, this.posicionGananciaY, this.gananciaCortesia.transform.position.z);
			this.posicionGananciaY+=4;
		}
	}

	public void aumentaDinero (int cantidad){
		if (cantidad > 0)
			this.audioDinero.clip = this.audioGanarDinero;

		else
			this.audioDinero.clip = this.audioPerderDinero;

		this.audioDinero.Play();
		VariablesGenerales.Instance.aumentaDinero (cantidad);

		if (VariablesGenerales.Instance.getDineroActual () >= 50)
			this.imagenDinero.color = new Color32(0, 66, 6, 255);

		else
			this.imagenDinero.color = new Color32(255, 0, 0, 150);

		this.imagenDinero.text = VariablesGenerales.Instance.getDineroActual ().ToString ();
	}

	public void aumentaCortesia (int cantidad) {
		if (cantidad > 0) {
			this.audioCortesia.clip = this.audioGanarCortesia;
			this.gananciaCortesia.color = new Color32(50, 71, 0, 255);
			this.gananciaCortesia.text = "+ " + cantidad.ToString();
		} 

		else {
			this.audioCortesia.clip = this.audioPerderCortesia;
			this.gananciaCortesia.color = new Color32(240, 63, 42, 255);
			this.gananciaCortesia.text = cantidad.ToString();
		}

		this.cambiarCortesia = true;
		this.gananciaCortesia.enabled = true;
		StartCoroutine (waitForCortesia ());
		this.audioCortesia.Play ();

		VariablesGenerales.Instance.aumentaCortesia (cantidad);
		this.imgCortesia.setImagenCortesia (VariablesGenerales.Instance.getCortesiaActual ());
	}

	IEnumerator waitForCortesia(){
		yield return new WaitForSeconds(1.5f);
		this.cambiarCortesia = false;
		this.posicionGananciaY = 30;
		this.gananciaCortesia.transform.position.Set (0, 0, 0);
		this.gananciaCortesia.enabled = false;
		this.barraCotesia.color = new Color32 (255, 255, 255, 255);
		this.colorCortesia = 255;
	}
}