using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMode : MonoBehaviour
{
    public GameObject rubiksArrows;
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
            //仮

            //回転可能、ロック解除、回せる残りが回数が1以上
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

    public void SwitchArrow(string faceTagName)
    {

        if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
        {
            //回転可能、ロック解除、回せる残りが回数が1以上で
            if (cubemover.isAvailable() && !cubemover.IsLocked()
            && (gameManager.RotateCount() >= 1))
            {
                rubiksArrows.gameObject.SetActive(true);
                for (int i = 0; i < 24; i++)
                {
                    rubiksArrows.transform.GetChild(i).gameObject.SetActive(true);
                }

                switch (faceTagName)
                {
                    case "Face1":

                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);
                        break;

                    case "Face2":
                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);
                        break;

                    case "Face3":
                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F9").gameObject.SetActive(false);
                        break;

                    case "Face4":
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);
                        break;

                    case "Face5":
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);

                        break;

                    case "Face6":
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);
                        break;

                    case "Face7":
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);
                        break;

                    case "Face8":
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);
                        break;

                    case "Face9":
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F9").gameObject.SetActive(false);
                        break;

                    default:
                        break;

                }
                //Debug.Log(faceTagName);
            }

            else
            {
                rubiksArrows.gameObject.SetActive(false);
            }
        }
    }

}
