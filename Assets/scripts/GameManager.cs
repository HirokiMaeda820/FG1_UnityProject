using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase _upCamera;
    [SerializeField] CinemachineVirtualCameraBase _sideCamera;

    [SerializeField] CinemachineVirtualCameraBase _selectCamera;

    public Transform _rubikArrows;

    private int cameraSwitch = 0;

    enum SwitchName
    {
        UP = 0,
        SIDE = 1,
        SELECT = 2
    }

    private void Start()
    {
        cameraSwitch = 0;
        _upCamera.MoveToTopOfPrioritySubqueue();
        _rubikArrows.gameObject.SetActive(false);
    }

    private void Update()
    {


        if (!Input.GetKey(KeyCode.Tab) && !Input.GetKey(KeyCode.Space))//Tabキー押してなかったら
        {
            cameraSwitch = (int)SwitchName.UP;
        }
        else if (!Input.GetKey(KeyCode.Space)) //Tabキー押してたら
        {
            cameraSwitch = (int)SwitchName.SIDE;
        }
        else if (Input.GetKey(KeyCode.Space))//スペース押したら選ぶ時用のカメラにする(仮)
        {
            cameraSwitch = (int)SwitchName.SELECT;
        }


        if (cameraSwitch == (int)SwitchName.UP)
        {
            _upCamera.MoveToTopOfPrioritySubqueue();//上からのカメラにする
            _rubikArrows.gameObject.SetActive(false);
        }
        else if (cameraSwitch == (int)SwitchName.SIDE)
        {
            _sideCamera.MoveToTopOfPrioritySubqueue();//回せるカメラにする
            _rubikArrows.gameObject.SetActive(false);
        }
        else if (cameraSwitch == (int)SwitchName.SELECT)
        {
            _selectCamera.MoveToTopOfPrioritySubqueue();//選ぶ時用のカメラにする(仮)
            _rubikArrows.gameObject.SetActive(true);
        }
    }
}

