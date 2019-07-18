using UnityEngine;
using System.Collections;

public class MovimientoMirilla : MonoBehaviour {
	public int speed = 5;

	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), speed * Time.deltaTime);
	}
}
