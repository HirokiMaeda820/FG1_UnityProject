using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase _upCamera;
    [SerializeField] CinemachineVirtualCameraBase _sideCamera;

    [SerializeField] CinemachineVirtualCameraBase _selectCamera;

    public Transform _rubikArrows;
    public CubeMover _cubeMover;

    private int cameraSwitch = 0;
    private int oldCamera = 0;


    enum SwitchName
    {
        UP = 0,
        SIDE = 1,
        SELECT = 2
    }

    private void Start()
    {
        cameraSwitch = 0;
        oldCamera = 0;
        _upCamera.MoveToTopOfPrioritySubqueue();
        _rubikArrows.gameObject.SetActive(false);
    }

    private void Update()
    {
        CameraSwitch(); //�؂�ւ�
        CameraSetting(); //�Z�b�g
    }

    private void CameraSwitch()
    {
        //�X�y�[�X��������I�����[�h
        if (Input.GetKeyDown(KeyCode.Space) && cameraSwitch != (int)SwitchName.SELECT)
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
            if (oldCamera == (int)SwitchName.SELECT)//�O���I�����[�h�Ȃ�
            {
                cameraSwitch = (int)SwitchName.SELECT;//�I�����[�h�ɂ���
            }
        }

    }

    private void CameraSetting()
    {
        if (cameraSwitch == (int)SwitchName.UP)
        {
            _upCamera.MoveToTopOfPrioritySubqueue();//�ォ��̃J�����ɂ���
            _rubikArrows.gameObject.SetActive(false);
        }
        else if (cameraSwitch == (int)SwitchName.SIDE)
        {
            _sideCamera.MoveToTopOfPrioritySubqueue();//�񂹂�J�����ɂ���
            _rubikArrows.gameObject.SetActive(false);
        }
        else if (cameraSwitch == (int)SwitchName.SELECT)
        {
            _selectCamera.MoveToTopOfPrioritySubqueue();//�I�����[�h�ɂ���

        }
    }
}
