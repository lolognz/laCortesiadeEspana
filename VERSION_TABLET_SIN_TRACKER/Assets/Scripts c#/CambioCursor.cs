using UnityEngine;
using System.Collections;

public class CambioCursor : MonoBehaviour {
	public Texture2D cursorTexture;
	private Texture2D cursorTexture2;
	private CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	void OnMouseEnter() {
		cursorMode = CursorDefecto.getDefaultCursorMode ();
		if (VariablesGenerales.Instance.getOnConversation())
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	void OnMouseExit() {
		cursorMode = CursorDefecto.getDefaultCursorMode ();
		cursorTexture2 = CursorDefecto.getDefaultCursor();
		Cursor.SetCursor(cursorTexture2, Vector2.zero, cursorMode);
	}
}