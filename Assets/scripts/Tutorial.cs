using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{


    private int tutorialCount;

    private float timer;
    public const float maxTimer = 3;
    private bool startTimer;

    public Text countText;
    private GameObject sideCamera;
    public CubeMover cubeMover;
    public CameraSwitcher cameraSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        tutorialCount = 0;
        timer = maxTimer;

        sideCamera = GameObject.Find("CameraSide");

        if (countText != null)
        {
            countText.text = "tutorial : " + tutorialCount;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //�X�L�b�v�{�^�����

        switch (tutorialCount)
        {
            case 0://�ŏ�
                //�v���C���[����̉摜

                //�ŏ��̓J�������ォ��ɌŒ�
                cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                //�v���C���[�����삳�ꂽ��1�ɂ���
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
                {
                    startTimer = true;
                }
                UpdateCount(1);

                break;
            case 1:
                //TAB�𐄂��Ȃ����]���ăS�[���̈ʒu���m�F����

                //�X�y�[�X�������Ȃ��悤�ɂ��������ǎv�����Ȃ����炱��ł�����
                if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
                {
                    cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                }

                //��]��������3�ɂ���
                float dis = Vector3.Distance(new Vector3(0, 0, -60), sideCamera.transform.position);
                if (dis > 7.0f)
                {
                    startTimer = true;


                }
                if(UpdateCount(2))
                {
                    cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                }

                break;
            case 2://SPACE�Ő؂�ւ���

                //�؂�ւ������3��
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    startTimer = true;
                }
                UpdateCount(3);


                break;
            case 3://��󉟂��ĉ�

                //���w�肷��

                //�񂵂���4
                if (cubeMover.GetIsRotate())
                {
                    startTimer = true;
                }
                UpdateCount(4);

                break;
            case 4://space�Ŗ߂�
                //�߂�����5
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    startTimer = true;
                }
                UpdateCount(5);

                break;
            case 5://�S�[�����悤

                // �S�[��������NextScene
                break;

        }
        countText.text = "tutorial : " + tutorialCount;

    }




    private bool UpdateCount(int nextCount)
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                tutorialCount = nextCount;
                timer = maxTimer;
                startTimer = false;
                return true;
            }
            return false;
        }
        return false;
    }
}
