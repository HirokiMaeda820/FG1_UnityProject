using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMode : MonoBehaviour
{
    public Transform rubiksArrows;
    public CubeMover cubemover;
    public CameraSwitcher cameraSwitcher;
    public GameManager gameManager;

    public void Start()
    {

        if (!cubemover.IsLocked())
        {
            rubiksArrows.gameObject.SetActive(true);
        }
        else
        {
            rubiksArrows.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraSwitcher.CameraSetting();

        if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.UP)
        {
            rubiksArrows.gameObject.SetActive(false);
        }
        else if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SIDE)
        {
            rubiksArrows.gameObject.SetActive(false);
        }
        else if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
        {
            //��]�\�A���b�N�����A�񂹂�c�肪�񐔂�1�ȏ�
            if (cubemover.isAvailable() && !cubemover.IsLocked() && (gameManager.RotateCount() >= 1))
            {
                rubiksArrows.gameObject.SetActive(true);
            }
            else
            {
                rubiksArrows.gameObject.SetActive(false);
            }
        }

    }

}
