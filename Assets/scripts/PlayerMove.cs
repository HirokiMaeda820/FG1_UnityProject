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

    /// <summary>動く速さ</summary>
    [SerializeField] float m_movingSpeed = 5f;
    /// <summary>ターンの速さ</summary>
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


        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            if (Camera.main != null)
            {
                dir = Camera.main.transform.TransformDirection(dir);
                // メインカメラを基準に入力方向のベクトルを変換する
                dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする
            }



            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);


            Vector3 velo = dir.normalized * m_movingSpeed; // 入力した方向に移動する
            velo.y = m_rb.velocity.y;   // ジャンプした時の y 軸方向の速度を保持する
            m_rb.velocity = velo;   // 計算した速度ベクトルをセットする
        }

    }
}
