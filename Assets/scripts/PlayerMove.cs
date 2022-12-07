using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMove : MonoBehaviour
{
    //public float speed = 3.0f;
    //public float rotateSpeed = 1.5f;

    public CameraSwitcher cameraSwitcher;
    CharacterController controller;

    /// <summary>��������</summary>
    [SerializeField] float m_movingSpeed = 5f;
    /// <summary>�^�[���̑���</summary>
    [SerializeField] float m_turnSpeed = 3f;

     Vector3 oldPos;

    Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.UP)
        {
            // controller.enabled = true;
            Move();
            oldPos = transform.position;
        }
        else
        {
            //controller.enabled = false;
            transform.position = oldPos;
        }
    }

    void Move()
    {
        //CharacterController controller = GetComponent<CharacterController>();

        //// Rotate around y - axis
        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        //// Move forward / backward
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        //float curSpeed = speed * Input.GetAxis("Vertical");
        //controller.SimpleMove(forward * curSpeed);


        // �����̓��͂��擾���A���������߂�
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


        // ���͕����̃x�N�g����g�ݗ��Ă�
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // �����̓��͂��j���[�g�����̎��́Ay �������̑��x��ێ����邾��
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            // �J��������ɓ��͂��㉺=��/��O, ���E=���E�ɃL�����N�^�[��������
            if (Camera.main != null)
            {
                dir = Camera.main.transform.TransformDirection(dir);
                // ���C���J��������ɓ��͕����̃x�N�g����ϊ�����
                dir.y = 0;  // y �������̓[���ɂ��Đ��������̃x�N�g���ɂ���
            }



            // ���͕����Ɋ��炩�ɉ�]������
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);


            Vector3 velo = dir.normalized * m_movingSpeed; // ���͂��������Ɉړ�����
            velo.y = m_rb.velocity.y;   // �W�����v�������� y �������̑��x��ێ�����
            m_rb.velocity = velo;   // �v�Z�������x�x�N�g�����Z�b�g����
        }

    }
}
