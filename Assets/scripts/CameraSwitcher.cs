using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class CameraSwitcher : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCameraBase _upCamera;
    [SerializeField] CinemachineVirtualCameraBase _sideCamera;
    [SerializeField] CinemachineVirtualCameraBase _playerCamera;

    [SerializeField] CinemachineVirtualCameraBase _selectCamera;

    public Transform _rubikArrows;
    public CubeMover _cubeMover;
    public GameManager _gameManager;
    public GameObject _player;


    private int cameraSwitch = 0;
    private int oldCamera = 0;


    public enum SwitchName
    {
        UP = 0,
        SIDE = 1,
        SELECT = 2
    }

    private void Start()
    {
        cameraSwitch = 0;
        oldCamera = 0;

        _playerCamera.MoveToTopOfPrioritySubqueue();
        //_upCamera.MoveToTopOfPrioritySubqueue();

    }

    private void Update()
    {
        //スペース押したら選択モード
        if (Input.GetKeyDown(KeyCode.Space) && cameraSwitch != (int)SwitchName.SELECT
            && _gameManager.RotateCount() >= 1) //回せる回数が1以上の時
        {
            cameraSwitch = (int)SwitchName.SELECT;
            oldCamera = (int)SwitchName.SELECT;
        }
        //スペース離したら上から視点
        else if (Input.GetKeyDown(KeyCode.Space) && cameraSwitch == (int)SwitchName.SELECT)
        {
            cameraSwitch = (int)SwitchName.UP; //上からに戻す
            oldCamera = (int)SwitchName.UP;
        }

        if (Input.GetKey(KeyCode.Tab)) //Tabキー押してたら
        {
            cameraSwitch = (int)SwitchName.SIDE; //見回すカメラ

        }

        else if (Input.GetKeyUp(KeyCode.Tab))//Tab離したとき
        {
            if (oldCamera == (int)SwitchName.UP)//前が上からのカメラなら
            {
                cameraSwitch = (int)SwitchName.UP;//上からのカメラにする
            }
            else if (oldCamera == (int)SwitchName.SELECT)//前が選択モードなら
            {
                cameraSwitch = (int)SwitchName.SELECT;//選択モードにする
            }
        }
    }

    public int CameraSwitch()
    {
        return cameraSwitch;
    }
    public void SetCameraSwitch(int switchNum)
    {
        cameraSwitch = switchNum;
    }


    public void CameraSetting()
    {
        if (CameraSwitch() == (int)SwitchName.UP)
        {
            _playerCamera.MoveToTopOfPrioritySubqueue();
          //_upCamera.MoveToTopOfPrioritySubqueue();//上からのカメラにする
          //  _player.SetActive(true);

        }
        else if (cameraSwitch == (int)SwitchName.SIDE)
        {
            _sideCamera.MoveToTopOfPrioritySubqueue();//回せるカメラにする
          //  _player.SetActive(false);


        }
        else if (cameraSwitch == (int)SwitchName.SELECT)
        {
            _selectCamera.MoveToTopOfPrioritySubqueue();//選択モードにする
           // _player.SetActive(true);

        }
    }



}
