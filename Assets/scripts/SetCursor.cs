using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{

    public CameraSwitcher cameraSwitcher;
    public Menu menu;
    public GameObject _goal;

    public Texture2D handCursor;
    public Texture2D arrowCursor;


    private void Start()
    {
        Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.Auto);
    }
    void Update()
    {

        if (Input.GetMouseButton(0) /*&& !crb.isHittingUI()*/)
        {
            Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
            //Debug.Log("�N���b�N");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(arrowCursor, Vector2.zero, CursorMode.Auto);
            //Debug.Log("������");
        }

        if (cameraSwitcher != null || menu != null)
        {
            if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.UP)
            {
                Cursor.visible = menu.GetIsPause();
            }
            else
            {
                Cursor.visible = true;
            }
            if (_goal.GetComponent<Goal>().GetIsGoal())//�N���A������J�[�\���o��
            {
                Cursor.visible = true;
            }
        }
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