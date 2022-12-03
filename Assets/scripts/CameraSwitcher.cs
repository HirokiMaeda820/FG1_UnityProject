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
    [SerializeField] CinemachineVirtualCameraBase _playerCamera;

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

        _mainCamera.SetActive(true);
        _goalCamera.SetActive(false);

        _goal = GameObject.Find("GoalCollider").GetComponent<Goal>();

        _frameImage.SetActive(false);

        _playerCamera.MoveToTopOfPrioritySubqueue();
        //_upCamera.MoveToTopOfPrioritySubqueue();

    }

    private void Update()
    {
        //�X�y�[�X��������I�����[�h
        if (Input.GetKeyDown(KeyCode.Space) && cameraSwitch != (int)SwitchName.SELECT
            && _gameManager.RotateCount() >= 1) //�񂹂�񐔂�1�ȏ�̎�
        {
            cameraSwitch = (int)SwitchName.SELECT;
            oldCamera = (int)SwitchName.SELECT;
        }
        //�X�y�[�X��������ォ�王�_
        else if (Input.GetKeyDown(KeyCode.Space) && cameraSwitch == (int)SwitchName.SELECT)
        {
            cameraSwitch = (int)SwitchName.UP; //�ォ��ɖ߂�
            oldCamera = (int)SwitchName.UP;
        }

        if (Input.GetKey(KeyCode.Tab)) //Tab�L�[�����Ă���
        {
            cameraSwitch = (int)SwitchName.SIDE; //���񂷃J����

        }

        else if (Input.GetKeyUp(KeyCode.Tab))//Tab�������Ƃ�
        {
            if (oldCamera == (int)SwitchName.UP)//�O���ォ��̃J�����Ȃ�
            {
                cameraSwitch = (int)SwitchName.UP;//�ォ��̃J�����ɂ���
            }
            else if (oldCamera == (int)SwitchName.SELECT)//�O���I�����[�h�Ȃ�
            {
                cameraSwitch = (int)SwitchName.SELECT;//�I�����[�h�ɂ���
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

    public void SetOldCamera(int oldNum)
    {
        oldCamera = oldNum;
    }


    public void CameraSetting()
    {
        //�v���C���[�̎�
        if (CameraSwitch() == (int)SwitchName.UP)
        {
            _playerCamera.MoveToTopOfPrioritySubqueue();

            _upCamera.SetActive(true);
            //  _player.SetActive(true);

            _frameImage.SetActive(false);
            _upCameraFrameImage.SetActive(true);
        }
        //���񂷎�
        else if (cameraSwitch == (int)SwitchName.SIDE)
        {
            _sideCamera.MoveToTopOfPrioritySubqueue();//�񂹂�J�����ɂ���
                                                      //  _player.SetActive(false);
            _upCamera.SetActive(false);
            _frameImage.SetActive(true);
            _upCameraFrameImage.SetActive(false);
        }
        //�񂷂Ƃ�
        else if (cameraSwitch == (int)SwitchName.SELECT)
        {
            _selectCamera.MoveToTopOfPrioritySubqueue();//�I�����[�h�ɂ���
                                                        // _player.SetActive(true);

            _upCamera.SetActive(false);
            _frameImage.SetActive(true);
            _upCameraFrameImage.SetActive(false);
        }

        //�S�[�����Ă���΂ߏォ�猩��
        if (_goal.GetIsGoal())
        {
            _mainCamera.SetActive(false);
            _goalCamera.SetActive(true);

            _upCamera.SetActive(false);
            _frameImage.SetActive(false);
            _upCameraFrameImage.SetActive(false);

            _rubikArrows.gameObject.SetActive(false);
        }
    }



}
