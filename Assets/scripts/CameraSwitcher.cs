using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _goalCamera;

    [SerializeField] GameObject _upCamera;
    [SerializeField] CinemachineVirtualCameraBase _sideCamera;
    [SerializeField] CinemachineVirtualCameraBase _playerFreeLookCamera;
    [SerializeField] CinemachineVirtualCameraBase _playerFollowCamera;

    [SerializeField] CinemachineVirtualCameraBase _selectCamera;

    public Transform _rubikArrows;
    public CubeMover _cubeMover;
    public GameManager _gameManager;
    public GameObject _player;

    private Goal _goal;

    private int cameraSwitch = 0;
    private int oldCamera = 0;

    public GameObject _frameImage;
    public GameObject _upCameraFrameImage;

    public GameObject icon_player;
    public GameObject icon_Rotate;
    public GameObject icon_select;

    public GameObject countText;

    public RectTransform menuBotton;
    public RectTransform resetBotton;

    public GameObject menu;

    static private bool playerMode = false;//false:FreeLook trur:Follow

    public bool selectScene = false;

    public enum SwitchName
    {
        UP = 0,
        SIDE = 1,
        SELECT = 2,
        Goal = 3
    }

    private void Start()
    {


        cameraSwitch = (int)SwitchName.UP;
        oldCamera = (int)SwitchName.UP;


        if (selectScene) return;

        _mainCamera.SetActive(true);
        _goalCamera.SetActive(false);

        _goal = GameObject.Find("GoalCollider").GetComponent<Goal>();

        _frameImage.SetActive(false);

        countText.SetActive(false);

        resetBotton.gameObject.SetActive(true);

        _playerFreeLookCamera.MoveToTopOfPrioritySubqueue();
        //_upCamera.MoveToTopOfPrioritySubqueue();

    }

    private void Update()
    {
        if (selectScene) return;
        if (menu.GetComponent<Menu>().GetIsPause()) return;

        //スペース押したら選択モード
        if (Input.GetKeyDown(KeyCode.Space) && cameraSwitch != (int)SwitchName.SELECT)
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


    public void CameraSetting()
    {
        //プレイヤーの時
        if (CameraSwitch() == (int)SwitchName.UP)
        {
            if (playerMode == false)
            {
                _playerFreeLookCamera.MoveToTopOfPrioritySubqueue();
            }
            else if (playerMode == true)
            {
                _playerFollowCamera.MoveToTopOfPrioritySubqueue();
            }


            _upCamera.SetActive(true);
            //  _player.SetActive(true);

            _frameImage.SetActive(false);
            _upCameraFrameImage.SetActive(true);

            icon_player.SetActive(true);
            icon_Rotate.SetActive(false);
            icon_select.SetActive(false);

            countText.SetActive(false);
            resetBotton.anchoredPosition = new Vector2(782, -465);
            menuBotton.anchoredPosition = new Vector2(889, -465);

        }
        //見回す時
        else if (cameraSwitch == (int)SwitchName.SIDE)
        {
            _sideCamera.MoveToTopOfPrioritySubqueue();//回せるカメラにする
                                                      //  _player.SetActive(false);
            _upCamera.SetActive(false);
            _frameImage.SetActive(true);
            _upCameraFrameImage.SetActive(false);

            icon_player.SetActive(false);
            icon_Rotate.SetActive(true);
            icon_select.SetActive(false);

            countText.SetActive(false);

            resetBotton.anchoredPosition = new Vector2(712, -422);
            menuBotton.anchoredPosition = new Vector2(823, -422);
        }
        //キューブ回すとき
        else if (cameraSwitch == (int)SwitchName.SELECT)
        {
            _selectCamera.MoveToTopOfPrioritySubqueue();//選択モードにする
                                                        // _player.SetActive(true);

            _upCamera.SetActive(false);
            _frameImage.SetActive(true);
            _upCameraFrameImage.SetActive(false);

            icon_player.SetActive(false);
            icon_Rotate.SetActive(false);
            icon_select.SetActive(true);

            countText.SetActive(true);

            resetBotton.anchoredPosition = new Vector2(712, -422);
            menuBotton.anchoredPosition = new Vector2(823, -422);
        }

        //ゴールしてたら斜め上から見る
        if (_goal.GetIsGoal())
        {
            _goalCamera.SetActive(true);

            _upCamera.SetActive(false);
            _frameImage.SetActive(false);
            _upCameraFrameImage.SetActive(false);

            icon_player.SetActive(false);
            icon_Rotate.SetActive(false);
            icon_select.SetActive(false);

            _rubikArrows.gameObject.SetActive(false);

            resetBotton.gameObject.SetActive(false);
        }
    }

    public int CameraSwitch()
    {
        return cameraSwitch;
    }
    public void SetCameraSwitch(int switchNum)
    {
        cameraSwitch = switchNum;
        Debug.Log("こんにちは");
    }

    public void SetOldCamera(int oldNum)
    {
        oldCamera = oldNum;
    }


    public void ChengePlayerMode1()
    {
        playerMode = false;
    }

    public void ChengePlayerMode2()
    {
        playerMode = true;
    }

    public bool GetPlayerMode()
    {
        return playerMode;
    }

}
