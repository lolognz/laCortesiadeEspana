using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class establecerCortesia : MonoBehaviour {

	public Sprite Honor0;
	public Sprite Honor10;
	public Sprite Honor20;
	public Sprite Honor30;
	public Sprite Honor40;
	public Sprite Honor50;
	public Sprite Honor60;
	public Sprite Honor70;
	public Sprite Honor80;
	public Sprite Honor90;
	public Sprite Honor100;

	public void setImagenCortesia(int honorActual) {
		switch (honorActual) {
		case 0: 
			this.gameObject.GetComponent<Image> ().sprite = Honor0;
			break;
		case 10: 
			this.gameObject.GetComponent<Image> ().sprite = Honor10;
			break;
		case 20: 
			this.gameObject.GetComponent<Image> ().sprite = Honor20;
			break;
		case 30: 
			this.gameObject.GetComponent<Image> ().sprite = Honor30;
			break;
		case 40: 
			this.gameObject.GetComponent<Image> ().sprite = Honor40;
			break;
		case 50: 
			this.gameObject.GetComponent<Image> ().sprite = Honor50;
			break;
		case 60: 
			this.gameObject.GetComponent<Image> ().sprite = Honor60;
			break;
		case 70: 
			this.gameObject.GetComponent<Image> ().sprite = Honor70;
			break;
		case 80: 
			this.gameObject.GetComponent<Image> ().sprite = Honor80;
			break;
		case 90: 
			this.gameObject.GetComponent<Image> ().sprite = Honor90;
			break;
		case 100: 
			this.gameObject.GetComponent<Image> ().sprite = Honor100;
			break;
		default:
			if (honorActual > 100)
				this.gameObject.GetComponent<Image> ().sprite = Honor100;

			else
				this.gameObject.GetComponent<Image> ().sprite = Honor0;

			break;
		}
		/*if (variablesGlobales.honor == 0) {
			gameObject.GetComponent<Image> ().sprite = Honor0;
		}

		else if (variablesGlobales.honor == 10) {
			gameObject.GetComponent<Image> ().sprite = Honor10;
		}

		else if (variablesGlobales.honor == 20) {
			gameObject.GetComponent<Image> ().sprite = Honor20;
		}

		else if (variablesGlobales.honor == 30) {
			gameObject.GetComponent<Image> ().sprite = Honor30;
		}

		else if (variablesGlobales.honor == 40) {
			gameObject.GetComponent<Image> ().sprite = Honor40;
		}

		else if (variablesGlobales.honor == 50) {
			gameObject.GetComponent<Image> ().sprite = Honor50;
		}

		else if (variablesGlobales.honor == 60) {
			gameObject.GetComponent<Image> ().sprite = Honor60;
		}

		else if (variablesGlobales.honor == 70) {
			gameObject.GetComponent<Image> ().sprite = Honor70;
		}

		else if (variablesGlobales.honor == 80) {
			gameObject.GetComponent<Image> ().sprite = Honor80;
		}

		else if (variablesGlobales.honor == 90) {
			gameObject.GetComponent<Image> ().sprite = Honor90;
		}

		else if (variablesGlobales.honor == 100) {
			gameObject.GetComponent<Image> ().sprite = Honor100;
		}*/
	}
}
