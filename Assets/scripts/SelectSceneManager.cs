using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SelectSceneManager : MonoBehaviour
{
    int selectCount = 0;

    bool isStart = false;
    float startTimer;

    float arrowTimer = 0;

    public GameManager gameManager;

    public GameObject rightArrow;
    public GameObject leftArrow;

    [SerializeField] CinemachineVirtualCameraBase camera0;
    [SerializeField] CinemachineVirtualCameraBase camera1;
    [SerializeField] CinemachineVirtualCameraBase camera2;
    [SerializeField] CinemachineVirtualCameraBase camera3;
    [SerializeField] CinemachineVirtualCameraBase camera4;
    // [SerializeField] CinemachineVirtualCameraBase camera5;

    AudioSource audioSource;
    public AudioClip ketteiAudio;
    public AudioClip arrpwAudio;

    // Start is called before the first frame update

    void Start()
    {
        isStart = false;
        selectCount = 5;
        startTimer = 100;
        arrowTimer = 0;
        camera4.MoveToTopOfPrioritySubqueue();

        leftArrow.SetActive(false);
        rightArrow.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectCountUpdate();

        ClickSelect();
    }

    private void SelectCountUpdate()
    {
        if (!isStart)
        {
            startTimer--;

            selectCount = (int)startTimer / 20;

            //audioSource.Play();
            if (selectCount <= 0)
            {
                arrowTimer += Time.deltaTime;
                selectCount = 0;
                camera0.MoveToTopOfPrioritySubqueue();

                if (arrowTimer > 1)
                {
                    selectCount = 0;
                    isStart = true;
                    leftArrow.SetActive(true);
                    rightArrow.SetActive(true);
                }
            }
        }

        if (isStart)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                selectCount--;
                audioSource.PlayOneShot(arrpwAudio);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                selectCount++;
                audioSource.PlayOneShot(arrpwAudio);
            }
        }

        if (selectCount < 0) selectCount = 4;
        if (selectCount > 4) selectCount = 0;

        if (selectCount == 0) camera0.MoveToTopOfPrioritySubqueue();
        if (selectCount == 1) camera1.MoveToTopOfPrioritySubqueue();
        if (selectCount == 2) camera2.MoveToTopOfPrioritySubqueue();
        if (selectCount == 3) camera3.MoveToTopOfPrioritySubqueue();
        if (selectCount == 4) camera4.MoveToTopOfPrioritySubqueue();
        //if (selectCount == 5) camera5.MoveToTopOfPrioritySubqueue();

        //選択
        if (Input.GetKeyDown(KeyCode.Space)){
            if (selectCount == 0) { gameManager.ChangeScene("tutorialScene"); audioSource.PlayOneShot(ketteiAudio); }
            else if (selectCount == 1) { gameManager.ChangeScene("stage1"); audioSource.PlayOneShot(ketteiAudio); }
            else if (selectCount == 2) { gameManager.ChangeScene("stage2"); audioSource.PlayOneShot(ketteiAudio); }
            else if (selectCount == 3) { gameManager.ChangeScene("stage3"); audioSource.PlayOneShot(ketteiAudio); }
            else if (selectCount == 4) { gameManager.ChangeScene("stage4"); audioSource.PlayOneShot(ketteiAudio); }
        }
    }

    private void ClickSelect()
    {
        if (!isStart) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("select0")) { gameManager.ChangeScene("tutorialScene"); audioSource.PlayOneShot(ketteiAudio); }
                else if (hit.collider.gameObject.CompareTag("select1")) { gameManager.ChangeScene("stage1"); audioSource.PlayOneShot(ketteiAudio); }
                else if (hit.collider.gameObject.CompareTag("select2")) { gameManager.ChangeScene("stage2"); audioSource.PlayOneShot(ketteiAudio); }
                else if (hit.collider.gameObject.CompareTag("select3")) { gameManager.ChangeScene("stage3"); audioSource.PlayOneShot(ketteiAudio); }
                else if (hit.collider.gameObject.CompareTag("select4")) { gameManager.ChangeScene("stage4"); audioSource.PlayOneShot(ketteiAudio); }
                //else if (hit.collider.gameObject.CompareTag("select5")) { gameManager.ChangeScene("masterMiyata"); audioSource.PlayOneShot(ketteiAudio); }

            }
        }
    }

    public void RightButton()
    {
        selectCount++;
        audioSource.PlayOneShot(arrpwAudio);
    }
    public void LeftBotton()
    {
        selectCount--;
        audioSource.PlayOneShot(arrpwAudio);
    }
}
