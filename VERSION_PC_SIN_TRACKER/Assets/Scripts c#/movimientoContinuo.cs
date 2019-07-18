using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movimientoContinuo : MonoBehaviour{

	public float speed = 5f;
	private Vector3 nextPos;
	private Vector3 lastClick;
	private Vector3 Animal;

	//animacion movimiento
	public Animator anim;

	void Start(){
		//posicion de inicio
		nextPos = transform.position;
		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){


		//Calculamos el punto de pivote del personaje
		float playerWidth = this.transform.position.y; //Player width
		float playerOffset = (playerWidth / 100) * 5; //calculate % offset

		//Si se hace click con el raton en la pantalla
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButton (0)) {
			lastClick = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(lastClick,Vector2.zero);
			if (hit.collider != null){
				nextPos = transform.position;
			}
			else{
				//Localizamos el walkPoint mas cercano
				nextPos = FindClosestWalkPoint (lastClick).transform.position;
				nextPos.y += playerOffset;
			}
		}

		//Activamos las animaciones segun la posicion a la que se dirige
		if (nextPos.x > transform.position.x) {
			anim.SetFloat ("VelX", 1);
			this.transform.rotation = new Quaternion (0, 0, 0, 0);
		} else if (nextPos.x < transform.position.x) {
			anim.SetFloat ("VelX", 1);
			this.transform.rotation = new Quaternion (0, 180, 0, 0);
		} else
			anim.SetFloat ("VelX", 0);
		if (nextPos.y > transform.position.y) {
			anim.SetBool ("arriba", true);
			anim.SetBool ("abajo", false);
		} else if (nextPos.y < transform.position.y) {
			anim.SetBool ("abajo", true);
			anim.SetBool ("arriba", false);
		} else {
			anim.SetBool ("arriba", false);
			anim.SetBool ("abajo", false);
		}
	
		//Move
		transform.position = Vector3.MoveTowards (transform.position, nextPos, Time.deltaTime * speed);

	}

	//Encuentra el walkPoint mas cercano
	public GameObject FindClosestWalkPoint(Vector3 click){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("walkPoint"); //objetos con etiqueta walkpoint
		GameObject closest = GameObject.FindGameObjectWithTag ("walkPoint");
		float distance = Mathf.Infinity;
		Vector3 position = click;
		foreach (GameObject go in gos){
			Vector3 diff = (go.transform.position - position);
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance){
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

}
