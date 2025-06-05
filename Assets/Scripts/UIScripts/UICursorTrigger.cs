using System;
using Unity.VisualScripting;
using UnityEngine;

public class UICursorTrigger : MonoBehaviour
{
    [SerializeField] public Texture2D interactiveCursorTexture;
    private Cursor interactiveCursor;
    public static bool cursorIsInteractive = false;

    public void OnPointerEnter()
    {
        cursorIsInteractive = true;
        Vector2 hotspot = new Vector2(interactiveCursorTexture.width / 2, 0);
        Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto);
    }

    public void OnPointerExit()
    {
        cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }
}
