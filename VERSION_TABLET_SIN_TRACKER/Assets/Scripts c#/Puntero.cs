using UnityEngine;
using System.Collections;

public class Puntero : MonoBehaviour {
	public Texture2D cursor;
	public int cursorSizeX = 16;
	public int cursorSizeY = 16;
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("ASDLKASLDJASJDLKASJDLASKJDASLKJ" + VariablesGenerales.Instance.getOnConversation());
			Cursor.SetCursor (cursor, new Vector2 (cursorSizeX, cursorSizeY),CursorMode.Auto);

	}
}
