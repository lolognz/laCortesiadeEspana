using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movimientoContinuo2 : MonoBehaviour {

	//public static Vector3 posicion; //Posicion a la que el protagonista se movera 
	public float speed = 2f; //velocidad
	private Vector3 target;

	//private Rigidbody2D rb;
	private Animator anim;
	private float frenteArriba;
	private float frenteAbajo;

	// Use this for initialization
	void Start () {
		target = this.transform.position;
		anim = GetComponent<Animator> ();
		//rb = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			anim.SetFloat ("VelX", 1);
			frenteArriba = target.y + 1;
			frenteAbajo = target.y - 1;
			if ((frenteArriba > this.transform.position.y) && (frenteAbajo < this.transform.position.y)){
				anim.SetBool ("arriba", false);
				anim.SetBool ("abajo", false);
			}
			else{
				if (target.y > this.transform.position.y){
					anim.SetBool ("arriba", true);
					anim.SetBool ("abajo", false);
				}
				if (target.y < this.transform.position.y){
					anim.SetBool ("arriba", false);
					anim.SetBool ("abajo", true);
				}
			}

		}
		if (target.x > this.transform.position.x) {
			this.transform.rotation = new Quaternion (0, 0, 0, 0);
		}
		if (target.x < this.transform.position.x) {
			this.transform.rotation = new Quaternion (0, 180, 0, 0);
		}
		this.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if (this.transform.position == target) {
			anim.SetFloat ("VelX", 0);
			anim.SetBool ("arriba", false);
			anim.SetBool ("abajo",false);
		}
	}
}
