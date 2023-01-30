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
    public GameObject player;

    public GameObject TitleBotton;
    public GameObject NextBotton;
    public GameObject ClearImage;

    public bool selectScene = false;

    // public GameObject canvas;
    // private Menu pause;

    private void Start()
    {
        Application.targetFrameRate = 60;   //60fps
        Screen.SetResolution(1920, 1080, true); // �t���X�N���[�����[�h

        rotateCount = rotateCountMax;
        if (rotateText != null)
        {
            rotateText.text = "�c���:" + rotateCount;
        }

        // pause = canvas.GetComponent<Menu>();
        Time.timeScale = 1;

        if (NextBotton != null) NextBotton.SetActive(false);
        if (ClearImage != null) ClearImage.SetActive(false);
        if (TitleBotton != null) TitleBotton.SetActive(false);
        if (player != null) player.SetActive(true);
    }

    void Update()
    {
        //R�L�[�Ń��Z�b�g����
        if (Input.GetKey(KeyCode.R) && !_goal.GetComponent<Goal>().GetIsGoal())
        {
            if (!selectScene) SceneReset();
        }
        //ESC��DELETE�Ń^�C�g��
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Delete))
        {
            ChangeScene("TitleScene");
        }

        ////�|�[�X��ʂ̂Ƃ�
        //if (pause.GetIsPause())
        //{

        //}

        //�S�[��������
        if (_goal.GetComponent<Goal>().GetIsGoal())
        {

            if (NextBotton != null) NextBotton.SetActive(true);
            if (ClearImage != null) ClearImage.SetActive(true);
            if (TitleBotton != null) TitleBotton.SetActive(true);
            if (player != null) player.SetActive(false);
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
        rotateText.text = "�c���:" + rotateCount;
    }

    public int RotateCount()
    {
        return rotateCount;
    }
}