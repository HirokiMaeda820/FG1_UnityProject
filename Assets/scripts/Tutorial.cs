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
                    cameraSwitcher.SetOldCamera((int)CameraSwitcher.SwitchName.UP);
                }

                //回転させたら3にする
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
            case 2://SPACEで切り替える、矢印押して回す

                //なんでもいいから1つ回そうね
                //回したら3
                if (cubeMover.GetIsRotate())
                {
                    startTimer = true;
                }
                UpdateCount(3);


                break;
            case 3://プレイヤーが乗ってるブロックは回せない

                //アニメーション？したら
                startTimer = true;
                if (UpdateCount(4))
                {
                    wall1.SetActive(false);
                    wall2.SetActive(true);
                }
                break;


            case 4://プレイヤーを横のブロックまで移動させる

                   //移動したら
                if (player.GetComponent<PlayerTutorialHitFace>().GetHitFace())
                {
                    startTimer = true;
                }
                if (UpdateCount(5))
                {
                    wall2.SetActive(false);
                }

                break;
            case 5://回転させてゴール

                // ゴールしたらNextScene
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
