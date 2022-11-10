using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focusRotate : MonoBehaviour
{
    public GameObject Object;　//フォーカスするオブジェクト
    public Vector2 rotationSpeed; 
    public bool reverse;

    //private GameObject Camera;//
    private Vector2 lastMousePosition;

    void Start()
    {
        //Camera = Camera.main;
       // Camera = GameObject.Find("CameraSide");
    }

    void Update()
    {
        // if (!Input.GetKey(KeyCode.Tab)) return;
       
        //アクティブな時しか動かないようにしたいね


        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                var x = (lastMousePosition.x - Input.mousePosition.x);
                var y = (Input.mousePosition.y - lastMousePosition.y);

                if (Mathf.Abs(x) < Mathf.Abs(y))
                    x = 0;
                else
                    y = 0;

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                this.transform.RotateAround(Object.transform.position, Vector3.up, newAngle.x);
                this.transform.RotateAround(Object.transform.position, transform.right, newAngle.y);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var x = (Input.mousePosition.x - lastMousePosition.x);
                var y = (lastMousePosition.y - Input.mousePosition.y);

                if (Mathf.Abs(x) < Mathf.Abs(y))
                    x = 0;
                else
                    y = 0;

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                this.transform.RotateAround(Object.transform.position, Vector3.up, newAngle.x);
                this.transform.RotateAround(Object.transform.position, transform.right, newAngle.y);
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}