using UnityEngine;
using System.Collections;

public class ReplaceCursor : MonoBehaviour {

    public Texture2D cursorTexture;  // Your cursor texture
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    int cursorSizeX = 12;  // set to width of your cursor texture
    int cursorSizeY = 16;  // set to height of your cursor texture

    void Start()
    {
        Cursor.visible = false;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Input.mousePosition.x - cursorSizeX / 2, (Screen.height - Input.mousePosition.y) - cursorSizeY / 2, cursorSizeX, cursorSizeY), cursorTexture);
    }

}
