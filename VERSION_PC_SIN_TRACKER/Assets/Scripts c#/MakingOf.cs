using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MakingOf : MonoBehaviour {

	public Sprite[] slides;
	private Image imagenActual;
	private Button botonDerecho;
	private Button botonIzquierdo;
	private int pagina = 0;

	void Start () {
		this.imagenActual = this.gameObject.GetComponent<Image> ();
		this.botonDerecho = GameObject.Find ("BotonDerecha").GetComponent<Button> ();
		this.botonIzquierdo = GameObject.Find ("BotonIzquierda").GetComponent<Button> ();
		this.botonIzquierdo.interactable = false;
	}

	public void pasarImagenDerecha() {
		this.pagina++;
		this.botonIzquierdo.interactable = true;
		if (this.pagina == this.slides.Length - 1)
			this.botonDerecho.interactable = false;

		this.imagenActual.sprite = this.slides [this.pagina];
	}

	public void pasarImagenIzquierda() {
		this.pagina--;
		this.botonDerecho.interactable = true;
		if (this.pagina == 0)
			this.botonIzquierdo.interactable = false;

		this.imagenActual.sprite = this.slides [this.pagina];
	}

	public void cargarMenuPrincipal() {
		if (VariableJuegoPasado.Instance.getJuegoPasado())
			GameObject.Find ("Loader").GetComponent<FadeInLevelLoader>().LoadLevel("MenuPrincipal2");
		
		else
			GameObject.Find ("Loader").GetComponent<FadeInLevelLoader>().LoadLevel("MenuPrincipal1");
	}
}