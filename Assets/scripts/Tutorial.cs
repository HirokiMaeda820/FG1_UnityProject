using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{


    private int tutorialCount;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        tutorialCount = 0;
        timer = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //�X�L�b�v�{�^�����

        switch (tutorialCount)
        {
            case 0://�ŏ�
                //�v���C���[����̉摜

                //���삳�ꂽ��1�ɂ���
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
                {
                    timer -= Time.deltaTime;
                }

                break;
            case 1:
                //TAB�ŉ�]���ăS�[���̈ʒu���m�F���悤

                //TAB�����ꂽ���]�̐���,2��

                break;
            case 2://SPACE�Ő؂�ւ���

                //�؂�ւ������3��

                break;
            case 3://��󉟂��ĉ�

                //�񂵂���4
                break;
            case 4://space�Ŗ߂�
                   //�߂�����5

                break;
            case 5://�S�[�����悤

                // �S�[��������NextScene
                break;

        }


    }


}
