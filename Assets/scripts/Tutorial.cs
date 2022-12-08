using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{


    private int tutorialCount;

    private float timer;
    private float maxTimer = 3;
    private bool startTimer;

    private GameObject sideCamera;
    public CubeMover cubeMover;
    public CameraSwitcher cameraSwitcher;
    public GameObject player;
    private Goal goal;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject aka;

    public Transform tutorialImages;

    // Start is called before the first frame update
    void Start()
    {
        tutorialCount = 0;
        timer = maxTimer;

        sideCamera = GameObject.Find("CameraSide");
        goal = GameObject.Find("GoalCollider").GetComponent<Goal>();

        wall1.SetActive(true);
        wall2.SetActive(false);
        aka.SetActive(false);
        //tutorialImages.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        //�X�L�b�v�{�^�����

        switch (tutorialCount)
        {
            case 0://�ŏ�
                //�v���C���[����̉摜
                tutorialImages.Find("tutorialImage1").gameObject.SetActive(true);

                //�ŏ��̓J�������ォ��ɌŒ�
                cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                //�v���C���[�����삳�ꂽ��1�ɂ���
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
                {
                    startTimer = true;
                }
                if (UpdateCount(1))
                {
                    tutorialImages.Find("tutorialImage1").gameObject.SetActive(false);
                }

                break;
            case 1:
                //TAB�𐄂��Ȃ����]���ăS�[���̈ʒu���m�F����
                tutorialImages.Find("tutorialImage2").gameObject.SetActive(true);

                //�X�y�[�X�������Ȃ��悤�ɂ��������ǎv�����Ȃ����炱��ł�����
                if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
                {
                    cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                    cameraSwitcher.SetOldCamera((int)CameraSwitcher.SwitchName.UP);
                }

                //��]��������2�ɂ���
                float dis = Vector3.Distance(new Vector3(0, 0, -60), sideCamera.transform.position);
                if (dis > 7.0f)
                {
                    startTimer = true;


                }
                if (UpdateCount(2))
                {
                    cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                    cameraSwitcher.SetOldCamera((int)CameraSwitcher.SwitchName.UP);
                    tutorialImages.Find("tutorialImage2").gameObject.SetActive(false);
                }

                break;
            case 2://SPACE�Ő؂�ւ���A��󉟂��ĉ�
                tutorialImages.Find("tutorialImage3").gameObject.SetActive(true);

                //�Ȃ�ł���������1�񂻂���
                //�񂵂���3
                if (cubeMover.GetIsRotate())
                {
                    startTimer = true;
                    maxTimer = 7;
                }
                if (UpdateCount(3))
                {
                    tutorialImages.Find("tutorialImage3").gameObject.SetActive(false);
                    maxTimer = 3;
                    aka.SetActive(true);
                }


                break;
            case 3://�v���C���[������Ă�u���b�N�͉񂹂Ȃ�
                tutorialImages.Find("tutorialImage4").gameObject.SetActive(true);
                //�A�j���[�V�����H������
                startTimer = true;

                if (UpdateCount(4))
                {

                    wall1.SetActive(false);
                    wall2.SetActive(true);
                    aka.SetActive(false);
                    tutorialImages.Find("tutorialImage4").gameObject.SetActive(false);
                }
                break;


            case 4://�v���C���[�����̃u���b�N�܂ňړ�������
                tutorialImages.Find("tutorialImage5").gameObject.SetActive(true);

                //�ړ�������
                if (player.GetComponent<PlayerTutorialHitFace>().GetHitFace())
                {
                    startTimer = true;
                }
                if (UpdateCount(5))
                {
                    wall2.SetActive(false);
                    tutorialImages.Find("tutorialImage5").gameObject.SetActive(false);
                }

                break;
            case 5://��]�����ăS�[��
                tutorialImages.Find("tutorialImage6").gameObject.SetActive(true);

                // �S�[��������NextScene
                break;

            default:
                Debug.Log("tutorial.cs");

                break;

        }

        //�S�[��������
        if (goal.GetIsGoal())
        {
            tutorialImages.Find("tutorialImage6").gameObject.SetActive(false);
        }
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

    public int GettuTorialCount()
    {
        return tutorialCount;
    }
}
