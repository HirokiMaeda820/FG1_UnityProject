using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //public GameObject door;//青
    public DoorOpen doorOpen;

    //壁のgameobjectをUnity上でアタッチする
    bool isActive;//true=スイッチ押した
   

    private void Start()
    {
        isActive = false;
      
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得
        if (other.gameObject.tag == "Player")
        {

            // 回転ループ終了後にEキーを受け付ける
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
