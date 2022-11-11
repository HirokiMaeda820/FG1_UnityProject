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
    public GameObject goal;

    private void Start()
    {
        rotateCount = rotateCountMax;
        rotateText.text = "RotateCount : " + rotateCount;
    }

    void Update()
    {
        //Rキーでリセットする
        if (Input.GetKey(KeyCode.R) && !goal.GetComponent<Goal>().GetIsGoal())
        {
            SceneReset();
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
        rotateText.text = "RotateCount : " + rotateCount;
    }

    public int RotateCount()
    {
        return rotateCount;
    }
}