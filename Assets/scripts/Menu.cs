using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject commander;

    private bool isPause = false;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);

        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
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
        }
        // 再開
        else if (!isPause)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            commander.SetActive(true);
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
    public bool GetIsPause()
    {
        return isPause;
    }

}