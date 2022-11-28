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
        //スキップボタン作る

        switch (tutorialCount)
        {
            case 0://最初
                //プレイヤー操作の画像

                //操作されたら1にする
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
                {
                    timer -= Time.deltaTime;
                }

                break;
            case 1:
                //TABで回転してゴールの位置を確認しよう

                //TAB押されたら回転の説明,2に

                break;
            case 2://SPACEで切り替える

                //切り替わったら3に

                break;
            case 3://矢印押して回す

                //回したら4
                break;
            case 4://spaceで戻す
                   //戻したら5

                break;
            case 5://ゴールしよう

                // ゴールしたらNextScene
                break;

        }


    }


}
