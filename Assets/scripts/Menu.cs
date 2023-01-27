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

    private AudioSource audioSource;

    [SerializeField] private AudioClip pauseSound;
    [SerializeField] private AudioClip backSound;
    [SerializeField] private AudioClip erabuSound;

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

        audioSource = GetComponent<AudioSource>();

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
            if (!isPause) audioSource.PlayOneShot(pauseSound);
            else if(isPause) audioSource.PlayOneShot(backSound);

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
        audioSource.PlayOneShot(pauseSound);
    }

    private void Resume()
    {
        isPause = false;
        audioSource.PlayOneShot(backSound);
    }

    private void Sousa()
    {
        menuNum = 2;
        audioSource.PlayOneShot(erabuSound);
    }

    private void Setting()
    {
        menuNum = 1;
        audioSource.PlayOneShot(erabuSound);
    }

    public void MenuBack()
    {
        menuNum = 0;
        audioSource.PlayOneShot(backSound);
    }


    //private void

    public bool GetIsPause()
    {
        return isPause;
    }

}