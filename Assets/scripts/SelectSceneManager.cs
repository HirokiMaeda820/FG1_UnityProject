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
    [SerializeField] CinemachineVirtualCameraBase camera5;

    // Start is called before the first frame update

    void Start()
    {
        isStart = false;
        selectCount = 5;
        startTimer = 180;
        arrowTimer = 0;
        camera5.MoveToTopOfPrioritySubqueue();

        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
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

            selectCount = (int)startTimer / 30;

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
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                selectCount++;
            }
        }

        if (selectCount < 0) selectCount = 5;
        if (selectCount > 5) selectCount = 0;

        if (selectCount == 0) camera0.MoveToTopOfPrioritySubqueue();
        if (selectCount == 1) camera1.MoveToTopOfPrioritySubqueue();
        if (selectCount == 2) camera2.MoveToTopOfPrioritySubqueue();
        if (selectCount == 3) camera3.MoveToTopOfPrioritySubqueue();
        if (selectCount == 4) camera4.MoveToTopOfPrioritySubqueue();
        if (selectCount == 5) camera5.MoveToTopOfPrioritySubqueue();

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
                     if (hit.collider.gameObject.CompareTag("select0")) gameManager.ChangeScene("tutorialScene");
                else if (hit.collider.gameObject.CompareTag("select1")) gameManager.ChangeScene("stage1");
                else if (hit.collider.gameObject.CompareTag("select2")) gameManager.ChangeScene("stage2");
                else if (hit.collider.gameObject.CompareTag("select3")) gameManager.ChangeScene("stage3");
                else if (hit.collider.gameObject.CompareTag("select4")) gameManager.ChangeScene("masterMiyata");
                else if (hit.collider.gameObject.CompareTag("select5")) gameManager.ChangeScene("masterMiyata");

            }
        }
    }

    public void RightButton()
    {
        selectCount++;
    }
    public void LeftBotton()
    {
        selectCount--;
    }
}
