using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class debugManager : MonoBehaviour
{

    private bool isDebug = false;
    [SerializeField] CinemachineVirtualCameraBase _debugCamera;



    // Start is called before the first frame update
    void Start()
    {
        isDebug = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isDebug = !isDebug;
        }

        if (isDebug)
        {
            _debugCamera.MoveToTopOfPrioritySubqueue();

        }

    }

    public bool GetIsDebug()
    {
        return isDebug;
    }
}
