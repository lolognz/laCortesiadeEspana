using UnityEngine;
using System.Collections;

public class CursorDefecto : MonoBehaviour {

	public Texture2D cursorTexture;
	public static Texture2D cursorTexture2;
	public CursorMode cursorMode = CursorMode.ForceSoftware;
	public static CursorMode cursorMode2 = CursorMode.ForceSoftware;
	public Vector2 hotSpot = Vector2.zero;
	// Use this for initialization
	void Start () {
		cursorTexture2 = cursorTexture;
		cursorMode2 = cursorMode;
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		DontDestroyOnLoad (this);
	}

	public static Texture2D getDefaultCursor(){
		return cursorTexture2;
	}
	public static CursorMode getDefaultCursorMode(){
		return cursorMode2;
	}
}
