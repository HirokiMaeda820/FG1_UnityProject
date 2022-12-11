using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject commander;

    [SerializeField] private GameObject sousaImg;
    [SerializeField] private Button sousaButton;
    [SerializeField] private Button sousamodoru;
   

    private bool isPause = false;
    private bool isSousa = false;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);

        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);

        sousaButton.onClick.AddListener(Sousa);
        sousamodoru.onClick.AddListener(SousaModoru);

        sousaButton.gameObject.SetActive(true);
        sousaImg.gameObject.SetActive(false);
        sousamodoru.gameObject.SetActive(false);

        commander.SetActive(true);
        isPause = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }

        //ポーズ中
        if (isPause)
        {
            Time.timeScale = 0;  // 時間停止
            pausePanel.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
            commander.SetActive(false);

            if (isSousa)
            {
                sousaImg.gameObject.SetActive(true);
                sousamodoru.gameObject.SetActive(true);
                sousaButton.gameObject.SetActive(false);
            }
            else if(!isSousa)
            {
                sousaImg.gameObject.SetActive(false);
                sousamodoru.gameObject.SetActive(false);
                sousaButton.gameObject.SetActive(true);
            }

        }
        //ポーズしてないとき
        else if (!isPause)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            commander.SetActive(true);

            sousaImg.gameObject.SetActive(false);
            sousamodoru.gameObject.SetActive(false);
            isSousa = false;
        }

    }


    private void Pause()
    {
        isPause = true;
    }

    private void Resume()
    {
        isPause = false;
    }

    private void Sousa()
    {
        isSousa = true;
    }

    private void SousaModoru()
    {
        isSousa= false;
    }

    //private void

    public bool GetIsPause()
    {
        return isPause;
    }

}