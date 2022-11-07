using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase _upCamera;
    [SerializeField] CinemachineVirtualCameraBase _sideCamera;

    [SerializeField] CinemachineVirtualCameraBase _selectCamera;

    private void Start()
    {
        _upCamera.MoveToTopOfPrioritySubqueue();
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.Tab))
        {
            _upCamera.MoveToTopOfPrioritySubqueue();
        }
        else if(!Input.GetKey(KeyCode.Space))
        {
            _sideCamera.MoveToTopOfPrioritySubqueue();
        }


        if (Input.GetKey(KeyCode.Space))
        {
            _selectCamera.MoveToTopOfPrioritySubqueue();
        }
    }
}
