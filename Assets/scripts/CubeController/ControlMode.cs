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

    public debugManager debugManager;
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

        if (debugManager != null)
        {
            if (!debugManager.GetIsDebug())
                cameraSwitcher.CameraSetting();
        }
        else
        {
            cameraSwitcher.CameraSetting();
        }


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

            ////回転可能、ロック解除、回せる残りが回数が1以上
            //if (cubemover.isAvailable() && !cubemover.IsLocked() && (gameManager.RotateCount() >= 1))
            //{
            //    rubiksArrows.gameObject.SetActive(true);
            //}
            //else
            //{
            //    rubiksArrows.gameObject.SetActive(false);
            //}
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
                for (int i = 0; i < rubiksArrows.transform.childCount; i++)
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


                    case "5Face1":
                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);
                        break;

                    case "5Face2":
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7-8").gameObject.SetActive(false);
                        break;

                    case "5Face3":
                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);
                        break;

                    case "5Face4":
                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8-9").gameObject.SetActive(false);
                        break;

                    case "5Face5":
                        rubiksArrows.transform.Find("Arrow_U1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F9").gameObject.SetActive(false);
                        break;

                    case "5Face6":
                        rubiksArrows.transform.Find("Arrow_U7-8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4-7").gameObject.SetActive(false);
                        break;
                    case "5Face7":
                        rubiksArrows.transform.Find("Arrow_U7-8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7-8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4-7").gameObject.SetActive(false);

                        break;

                    case "5Face8":
                        rubiksArrows.transform.Find("Arrow_U7-8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);

                        break;

                    case "5Face9":
                        rubiksArrows.transform.Find("Arrow_U7-8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8-9").gameObject.SetActive(false);

                        break;
                    case "5Face10":
                        rubiksArrows.transform.Find("Arrow_U7-8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F9").gameObject.SetActive(false);
                        break;

                    case "5Face11":
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);
                        break;

                    case "5Face12":
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7-8").gameObject.SetActive(false);

                        break;

                    case "5Face13":
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);

                        break;
                    case "5Face14":
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8-9").gameObject.SetActive(false);

                        break;
                    case "5Face15":
                        rubiksArrows.transform.Find("Arrow_U8").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F9").gameObject.SetActive(false);

                        break;
                    case "5Face16":
                        rubiksArrows.transform.Find("Arrow_U8-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);

                        break;
                    case "5Face17":
                        rubiksArrows.transform.Find("Arrow_U8-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7-8").gameObject.SetActive(false);

                        break;
                    case "5Face18":
                        rubiksArrows.transform.Find("Arrow_U8-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);
                        break;
                    case "5Face19":
                        rubiksArrows.transform.Find("Arrow_U8-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8-9").gameObject.SetActive(false);
                        break;

                    case "5Face20":
                        rubiksArrows.transform.Find("Arrow_U8-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U2-3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R3-6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_R1-4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F9").gameObject.SetActive(false);
                        break;

                    case "5Face21":
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7").gameObject.SetActive(false);

                        break;
                    case "5Face22":
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4-7").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6-9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F1-2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F7-8").gameObject.SetActive(false);

                        break;
                    case "5Face23":
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);

                        break;
                    case "5Face24":
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U4").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U6").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F2").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_F8").gameObject.SetActive(false);

                        break;
                    case "5Face25":
                        rubiksArrows.transform.Find("Arrow_U9").gameObject.SetActive(false);
                        rubiksArrows.transform.Find("Arrow_U3").gameObject.SetActive(false);
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
