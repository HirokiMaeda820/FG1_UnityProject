using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public int rotateCountMax;
    private int rotateCount;
    public Text rotateText;

    public GameObject _goal;

    public GameObject TitleBotton;
    public GameObject NextBotton;
    public GameObject ClearImage;


    private void Start()
    {
        Application.targetFrameRate = 60;   //60fps
        Screen.SetResolution(1920, 1080, true); // フルスクリーンモード

        rotateCount = rotateCountMax;
        if (rotateText != null)
        {
            rotateText.text = "残り回数 : " + rotateCount;
        }


        if (NextBotton != null) NextBotton.SetActive(false);
        if (ClearImage != null) ClearImage.SetActive(false);
        if (TitleBotton != null) TitleBotton.SetActive(false);
    }

    void Update()
    {
        //Rキーでリセットする
        if (Input.GetKey(KeyCode.R) && !_goal.GetComponent<Goal>().GetIsGoal())
        {
            SceneReset();
        }
        //ESCとDELETEでタイトル
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Delete))
        {
            ChangeScene("TitleScene");
        }

        //ゴールしたら
        if (_goal.GetComponent<Goal>().GetIsGoal())
        {

            if (NextBotton != null) NextBotton.SetActive(true);
            if (ClearImage != null) ClearImage.SetActive(true);
            if (TitleBotton != null) TitleBotton.SetActive(true);
        }
    }

    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void subRotateCount()
    {
        rotateCount = rotateCount - 1;
        rotateText.text = "残り回数 : " + rotateCount;
    }

    public int RotateCount()
    {
        return rotateCount;
    }
}