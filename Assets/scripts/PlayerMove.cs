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


    Rigidbody m_rb;
    Animator anime_;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_rb = GetComponent<Rigidbody>();
        anime_ = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float v = 0; float h = 0;

        if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.UP)

        {
            // �����̓��͂��擾���A���������߂�
            v = Input.GetAxisRaw("Vertical");
            h = Input.GetAxisRaw("Horizontal");

            //if (v != 0 || h != 0) anime_.SetBool("walk", true);
            //else anime_.SetBool("walk", false);

        }
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
            //if (velo != Vector3.zero) transform.Rotate(new Vector3(0, 90, 0));

            m_rb.velocity = velo;   // �v�Z�������x�x�N�g�����Z�b�g����
        }
        //�����L�[����������A�j���[�^�[.setbool("walk",true);��ς���
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anime_.SetBool("walk", true);
        }
        //else
        //{
        //    anime_.SetBool("walk", false);
        //}
        else if (!Input.anyKey)
        {
            anime_.SetBool("walk", false);
        }
    }
}
