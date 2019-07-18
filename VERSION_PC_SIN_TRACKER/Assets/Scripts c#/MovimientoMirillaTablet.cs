using UnityEngine;
using System.Collections;

public class MovimientoMirillaTablet : MonoBehaviour {
	public int speed = 5;

	// Update is called once per frame
	void Update () {

		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		dir.y = Input.acceleration.y;
		dir *= Time.deltaTime;
		
		this.transform.Translate (dir * speed);
	}
}
