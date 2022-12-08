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

        //スキップボタン作る

        switch (tutorialCount)
        {
            case 0://最初
                //プレイヤー操作の画像
                tutorialImages.Find("tutorialImage1").gameObject.SetActive(true);

                //最初はカメラを上からに固定
                cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                //プレイヤーが操作されたら1にする
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
                //TABを推しながら回転してゴールの位置を確認する
                tutorialImages.Find("tutorialImage2").gameObject.SetActive(true);

                //スペース反応しないようにしたいけど思いつかないからこれでいいや
                if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
                {
                    cameraSwitcher.SetCameraSwitch((int)CameraSwitcher.SwitchName.UP);
                    cameraSwitcher.SetOldCamera((int)CameraSwitcher.SwitchName.UP);
                }

                //回転させたら2にする
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
            case 2://SPACEで切り替える、矢印押して回す
                tutorialImages.Find("tutorialImage3").gameObject.SetActive(true);

                //なんでもいいから1つ回そうね
                //回したら3
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
            case 3://プレイヤーが乗ってるブロックは回せない
                tutorialImages.Find("tutorialImage4").gameObject.SetActive(true);
                //アニメーション？したら
                startTimer = true;

                if (UpdateCount(4))
                {

                    wall1.SetActive(false);
                    wall2.SetActive(true);
                    aka.SetActive(false);
                    tutorialImages.Find("tutorialImage4").gameObject.SetActive(false);
                }
                break;


            case 4://プレイヤーを横のブロックまで移動させる
                tutorialImages.Find("tutorialImage5").gameObject.SetActive(true);

                //移動したら
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
            case 5://回転させてゴール
                tutorialImages.Find("tutorialImage6").gameObject.SetActive(true);

                // ゴールしたらNextScene
                break;

            default:
                Debug.Log("tutorial.cs");

                break;

        }

        //ゴールしたら
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
