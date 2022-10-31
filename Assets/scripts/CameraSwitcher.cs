using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase _mainCamera;
    [SerializeField] CinemachineVirtualCameraBase _subCamera;

    bool changeCamera = false;//false:main true:sub

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            changeCamera = !changeCamera;
        }

        if (changeCamera)
        {
            _mainCamera.MoveToTopOfPrioritySubqueue();
        }
        else
        {
            _subCamera.MoveToTopOfPrioritySubqueue();
        }
    }
}
