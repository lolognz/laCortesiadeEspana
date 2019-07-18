using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversacionCutSceneSonido : MonoBehaviour {
	
	public GameObject conversante1;
	public GameObject conversante2;
	
	public string siguienteEscena;
	private bool primeraConversacion;
	private bool siguienteConversacion;
	
	public string fichero;
	
	private Animator anim1;
	private Animator anim2;
	
	private Text texto;
	private string[] conversaciones;
	private string contenidoFichero;
	private int numConver;
	
	//En orden de reproduccion
	private AudioSource audioActual;
	public AudioClip audio1;
	public AudioClip audio2;
	public AudioClip audio3;
	public AudioClip audio4;
	public AudioClip audio5;
	public AudioClip audio6;
	public AudioClip audio7;
	public AudioClip audio8;
	
	void Start () {
		this.anim1 = this.conversante1.GetComponent<Animator> ();
		this.anim2 = this.conversante2.GetComponent<Animator> ();
		
		this.texto = GameObject.Find ("Dialogo").GetComponent<Text> ();
		
		TextAsset archivo = Resources.Load(this.fichero) as TextAsset;
		this.contenidoFichero = archivo.text;
		this.conversaciones = this.contenidoFichero.Split ('\n');
		this.numConver = 0;
		this.primeraConversacion = true;
		this.siguienteConversacion = false;
		
		this.audioActual = this.gameObject.GetComponent<AudioSource> ();
		//Inicializamos el clip del audio.
		this.audioActual.clip = this.audio1;

		if (this.fichero == "Transicion1")
			this.anim2.SetBool("contenta", false);
	}
	
	void FixedUpdate () {
		if (this.primeraConversacion) {
			//Poner un yield de un par de segundos si se viera necesario
			this.anim1.SetBool("hablando", true);
			this.audioActual.Play();
			this.primeraConversacion = false;
			this.texto.text = this.conversaciones[this.numConver];
			this.numConver++;
		}
		
		else if (Input.GetMouseButtonDown(0) || this.siguienteConversacion) {
			this.siguienteConversacion = false;
			this.audioActual.Stop();
			
			if (this.numConver < this.conversaciones.Length) {
				if (this.numConver%2 == 0) {	//Conversante 1
					this.anim2.SetBool("hablando", false);
					this.anim1.SetBool("hablando", true);
				}
				
				else {	//Conversante 2
					this.anim1.SetBool("hablando", false);
					this.anim2.SetBool("hablando", true);
				}
				
				this.reproducirAudioActual();
				this.texto.text = this.conversaciones[this.numConver];
				this.numConver++;
			}
			
			else {
				this.anim1.SetBool("hablando", false);
				this.anim2.SetBool("hablando", false);
				GameObject.Find ("Loader").GetComponent<FadeInLevelLoader> ().LoadLevel (this.siguienteEscena);
				//Application.LoadLevel(this.siguienteEscena);
			}
		}
		
		if (!this.audioActual.isPlaying) {
			//this.anim2.SetBool("hablando", false);
			//this.anim1.SetBool("hablando", false);
			this.siguienteConversacion = true;
		}
	}
	
	private void reproducirAudioActual() {
		switch (this.numConver) {
		case 0:
			this.audioActual.clip = this.audio1;
			break;
		case 1:
			this.audioActual.clip = this.audio2;
			break;
		case 2:
			this.audioActual.clip = this.audio3;
			break;
		case 3:
			this.audioActual.clip = this.audio4;
			break;
		case 4:
			this.audioActual.clip = this.audio5;
			break;
		case 5:
			this.audioActual.clip = this.audio6;
			break;
		case 6:
			this.audioActual.clip = this.audio7;
			break;
		case 7:
			this.audioActual.clip = this.audio8;
			if (this.fichero == "Transicion1")
				this.anim2.SetBool("contenta", true);

			break;
		default:
			break;
		}
		
		this.audioActual.Play ();
	}
}