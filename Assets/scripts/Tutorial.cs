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

        //スキップボタン作る

        switch (tutorialCount)
        {
            case 0://最初
                //プレイヤー操作の画像

                //最初はカメラを上からに固定
                cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                //プレイヤーが操作されたら1にする
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
                {
                    startTimer = true;
                }
                UpdateCount(1);

                break;
            case 1:
                //TABを推しながら回転してゴールの位置を確認する

                //スペース反応しないようにしたいけど思いつかないからこれでいいや
                if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
                {
                    cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                }

                //回転させたら3にする
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
            case 2://SPACEで切り替える

                //切り替わったら3に
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    startTimer = true;
                }
                UpdateCount(3);


                break;
            case 3://矢印押して回す

                //矢印指定する

                //回したら4
                if (cubeMover.GetIsRotate())
                {
                    startTimer = true;
                }
                UpdateCount(4);

                break;
            case 4://spaceで戻す
                //戻したら5
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    startTimer = true;
                }
                UpdateCount(5);

                break;
            case 5://ゴールしよう

                // ゴールしたらNextScene
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
