using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class focusRotate : MonoBehaviour
{
    public GameObject Object;　//フォーカスするオブジェクト
    static private Vector2 rotationSpeed = new Vector2(0.1f, 0.1f);
    private bool reverse = true;

    public CameraSwitcher cameraSwitcher;
    private Vector2 lastMousePosition;

    public GameObject menu;

    bool sideCameraReset;
    private Slider slider;

    public bool fiveRow = false;//false:3列 true:5列

    void Start()
    {
        //Camera = Camera.main;
        // Camera = GameObject.Find("CameraSide");
        sideCameraReset = false;
        slider = GameObject.Find("kandoSlider").GetComponent<Slider>();
        slider.value = rotationSpeed.x;
    }

    void Update()
    {
       
        //アクティブじゃないときはreturn
        if (!(cameraSwitcher.CameraSwitch() == 1))
        {
            //sideCameraReset = false;
            return;
        }

        if (menu.GetComponent<Menu>().GetIsPause()) return;

        if (sideCameraReset)
        {
            if (!fiveRow) transform.position = new Vector3(0, 0, -60.0f);
            if (fiveRow) transform.position = new Vector3(0, 0, -100.0f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            sideCameraReset = false;
        }

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

    public void changeSpeed()
    {
        rotationSpeed.x = slider.value;
        rotationSpeed.y = slider.value;
        Debug.Log(slider.value);
    }

    public void ResetCamera()
    {
        sideCameraReset = true;
    }

}