using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Switch _switch;
    bool finish = false;
    public void DoorMove()
    {
        //startcortine(�֐���)
        StartCoroutine("DoorRotate");
    }
    //�R���[�`��
    IEnumerator DoorRotate()
    {

        if (_switch.GetIsActive() == false)
        {
            finish = !finish; // ���[�v�I����҂�
            for (int turn = 0; turn < 90; turn++)
            {                
                transform.Rotate(0, 1, 0);               
                yield return new WaitForSeconds(0.01f); // �������ꎞ��~���Ă������Ɖ�

            }

            yield return finish = !finish;
        }


        else if (_switch.GetIsActive() == true)
        {
            finish = !finish; // ���[�v�I����҂@
            for (int turn = 0; turn < 90; turn++)
            {
                transform.Rotate(0, -1, 0);
                yield return new WaitForSeconds(0.01f); // �������ꎞ��~���Ă������Ɖ�
            }
            yield return finish = !finish;
        }
    }

    public bool GetIsFinish()
    {
        return finish;
    }
}
