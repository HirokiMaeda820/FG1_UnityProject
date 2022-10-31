using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCameraBase _upCamera;
    [SerializeField] CinemachineVirtualCameraBase _sideCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            _sideCamera.MoveToTopOfPrioritySubqueue();
        }
        else
        {
            _upCamera.MoveToTopOfPrioritySubqueue();
        }
    }
}

