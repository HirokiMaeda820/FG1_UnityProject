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
        Application.targetFrameRate = 60;   //60fps
        Screen.SetResolution(1920, 1080, true); // �t���X�N���[�����[�h

        rotateCount = rotateCountMax;
        if (rotateText != null)
        {
            rotateText.text = "�c��� : " + rotateCount;
        }
    }

    void Update()
    {
        //R�L�[�Ń��Z�b�g����
        if (Input.GetKey(KeyCode.R) && !goal.GetComponent<Goal>().GetIsGoal())
        {
            SceneReset();
        }
        //ESC��DELETE�Ń^�C�g��
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Delete))
        {
            ChangeScene("TitleScene");
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
        rotateText.text = "�c��� : " + rotateCount;
    }

    public int RotateCount()
    {
        return rotateCount;
    }
}