using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValidacionCodigoUsuario : MonoBehaviour {
	
	private Text codigo;
	private Text mensaje;
	private Button botonAceptar;
	
	void Start () {
		this.codigo = GameObject.Find("Codigo").GetComponent<Text>();
		this.mensaje = GameObject.Find("Mensaje").GetComponent<Text>();
		this.botonAceptar = GameObject.Find("AceptarCodigo").GetComponent<Button>();
		this.mensaje.enabled = false;
	}

	void FixedUpdate() {
		if (Input.GetKey ("return") || Input.GetKey(KeyCode.KeypadEnter))
			this.aceptarCodigo ();
	}
	
	public void aceptarCodigo() {
		if (this.codigo.text == "") {
			this.mensaje.text = "No has introducido el codigo";
			this.mensaje.color = Color.red;
			this.mensaje.enabled = true;
		} 
		
		else {
			int cod = -7;
			cod = int.Parse(this.codigo.text);
			
			if (cod/100 > 0 && cod/100 < 10) {
				VariableCodigoUsuario.Instance.setCodigoUsuario(cod);
				this.botonAceptar.interactable = false;
				this.mensaje.text = "Codigo correcto";
				this.mensaje.color = new Color32(52, 98, 0, 255);
				this.mensaje.enabled = true;
				GameObject.Find("Loader").GetComponent<FadeInLevelLoader>().LoadLevel("MenuPrincipal1");
			}

			else if (cod == -7) {
				VariableCodigoUsuario.Instance.setCodigoUsuario(-7);
				this.botonAceptar.interactable = false;
				this.mensaje.text = "Analytics desahabilitado";
				this.mensaje.color = new Color32(52, 98, 0, 255);
				this.mensaje.enabled = true;
				GameObject.Find("Loader").GetComponent<FadeInLevelLoader>().LoadLevel("MenuPrincipalSinAnalytics");
			}
			
			else {
				this.mensaje.text = "Codigo incorrecto";
				this.mensaje.color = Color.red;
				this.mensaje.enabled = true;
			}
		}
	}
}