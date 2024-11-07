using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotspot;
    public void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

    public void SetDeffault()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
