using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //public GameObject door;//��
    public DoorOpen doorOpen;

    //�ǂ�gameobject��Unity��ŃA�^�b�`����
    bool isActive;//true=�X�C�b�`������
   

    private void Start()
    {
        isActive = false;
      
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(collision.gameObject.name); // �Ԃ���������̖��O���擾
        if (other.gameObject.tag == "Player")
        {

            // ��]���[�v�I�����E�L�[���󂯕t����
            if (Input.GetKeyDown(KeyCode.E)&& !doorOpen.GetIsFinish())
            {

                doorOpen.DoorMove();
                isActive = !isActive;

            }
        }
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}
