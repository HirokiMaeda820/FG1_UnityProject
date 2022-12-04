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
    public GameObject player;

    public GameObject wall1;
    public GameObject wall2;

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
        wall1.SetActive(true);
        wall2.SetActive(false);
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
                    cameraSwitcher.SetOldCamera((int)CameraSwitcher.SwitchName.UP);
                }

                //��]��������3�ɂ���
                float dis = Vector3.Distance(new Vector3(0, 0, -60), sideCamera.transform.position);
                if (dis > 7.0f)
                {
                    startTimer = true;


                }
                if (UpdateCount(2))
                {
                    cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                    cameraSwitcher.SetOldCamera((int)CameraSwitcher.SwitchName.UP);
                }

                break;
            case 2://SPACE�Ő؂�ւ���A��󉟂��ĉ�

                //�Ȃ�ł���������1�񂻂���
                //�񂵂���3
                if (cubeMover.GetIsRotate())
                {
                    startTimer = true;
                }
                UpdateCount(3);


                break;
            case 3://�v���C���[������Ă�u���b�N�͉񂹂Ȃ�

                //�A�j���[�V�����H������
                startTimer = true;
                if (UpdateCount(4))
                {
                    wall1.SetActive(false);
                    wall2.SetActive(true);
                }
                break;


            case 4://�v���C���[�����̃u���b�N�܂ňړ�������

                   //�ړ�������
                if (player.GetComponent<PlayerTutorialHitFace>().GetHitFace())
                {
                    startTimer = true;
                }
                if (UpdateCount(5))
                {
                    wall2.SetActive(false);
                }

                break;
            case 5://��]�����ăS�[��

                // �S�[��������NextScene
                break;

                default:
                Debug.Log("tutorial.cs");

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
