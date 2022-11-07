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


        if (!Input.GetKey(KeyCode.Tab) && !Input.GetKey(KeyCode.Space))//Tab�L�[�����ĂȂ�������
        {
            cameraSwitch = (int)SwitchName.UP;
        }
        else if (!Input.GetKey(KeyCode.Space)) //Tab�L�[�����Ă���
        {
            cameraSwitch = (int)SwitchName.SIDE;
        }
        else if (Input.GetKey(KeyCode.Space))//�X�y�[�X��������I�Ԏ��p�̃J�����ɂ���(��)
        {
            cameraSwitch = (int)SwitchName.SELECT;
        }


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
            _selectCamera.MoveToTopOfPrioritySubqueue();//�I�Ԏ��p�̃J�����ɂ���(��)
            _rubikArrows.gameObject.SetActive(true);
        }
    }
}

