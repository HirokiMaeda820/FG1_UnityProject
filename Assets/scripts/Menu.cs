using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject commander;

    [SerializeField] private Button sousaButton;
    [SerializeField] private Button settingButton;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject sousaPanel;
    [SerializeField] private GameObject settingPanel;

    private int menuNum = 0;//0:無 1:設定 2:操作説明
    private bool isPause = false;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);

        pauseButton.gameObject.SetActive(true);

        sousaButton.onClick.AddListener(Sousa);
        settingButton.onClick.AddListener(Setting);
        //メニューに戻る系はinspectorから

        sousaButton.gameObject.SetActive(true);


        if (commander != null)
        {
            commander.GetComponent<CtrlKeyMouse>().enabled = true;
        }
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
            pausePanel.SetActive(true);　　//パネルを出す
            pauseButton.gameObject.SetActive(false); //ポーズボタンを消す
            if (commander != null)
            {
                commander.GetComponent<CtrlKeyMouse>().enabled = false;
            }
            switch (menuNum)//0:無 1:設定 2:操作説明
            {
                case 0: //メニュー
                    menuPanel.SetActive(true);
                    settingPanel.SetActive(false);
                    sousaPanel.SetActive(false);
                    break;

                case 1: //設定
                    settingPanel.SetActive(true);
                    menuPanel.SetActive(false);
                    break;

                case 2: //操作説明
                    sousaPanel.SetActive(true);
                    menuPanel.SetActive(false);
                    break;
            }


        }
        //ポーズしてないとき
        else if (!isPause)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            if (commander != null)
            {
                commander.GetComponent<CtrlKeyMouse>().enabled = true;
            }
            menuNum = 0;
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
        menuNum = 2;
    }

    private void Setting()
    {
        menuNum = 1;
    }

    public void MenuBack()
    {
        menuNum = 0;
    }


    //private void

    public bool GetIsPause()
    {
        return isPause;
    }

}