using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public Texture2D handCursor;
    public Texture2D arrowCursor;


    private void Start()
    {
        Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.Auto);
    }
    void Update()
    {

        //if (Input.GetMouseButton(0) /*&& !crb.isHittingUI()*/)
        //{
        //    Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        //    Debug.Log("ƒNƒŠƒbƒN");
        //}
        //else if(!Input.GetMouseButtonDown(0))
        //{
        //   Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.Auto);
        //}


    }
    void OnMouseOver()
    {
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseDown()
    {
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseUp()
    {
        Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.Auto);
    }
}