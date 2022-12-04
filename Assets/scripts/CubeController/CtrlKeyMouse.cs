using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlKeyMouse : MonoBehaviour
{
    public CubeMover cubemover;
   // private Goal goal;

   // public Camera goalCamera;

    //public CanvasRaycastBlocker crb;

    // Start is called before the first frame update
    void Start()
    {
        //goal = GameObject.Find("GoalCollider").GetComponent<Goal>();
    }

    // Update is called once per frame
    void Update()
    {

        // Check for mouse input
        if (Input.GetMouseButtonDown(0) /*&& !crb.isHittingUI()*/)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (!goal.GetIsGoal()) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (goal.GetIsGoal()) ray = goalCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.name)
                {
                    case "Arrow_F1":
                        cubemover.move("L_B");
                        break;
                    case "Arrow_F2":
                        cubemover.move("Rm_B");
                        break;
                    case "Arrow_F3":
                        cubemover.move("R_B");
                        break;
                    case "Arrow_F4":
                        cubemover.move("Um_L");
                        break;
                    case "Arrow_F50":
                        cubemover.move("A_UL");
                        break;
                    case "Arrow_F51":
                        cubemover.move("A_UR");
                        break;
                    case "Arrow_F6":
                        cubemover.move("Um_R");
                        break;
                    case "Arrow_F7":
                        cubemover.move("L_F");
                        break;
                    case "Arrow_F8":
                        cubemover.move("Rm_F");
                        break;
                    case "Arrow_F9":
                        cubemover.move("R_F");
                        break;
                    case "Arrow_R1":
                        cubemover.move("D_L");
                        break;
                    case "Arrow_R2":
                        cubemover.move("Um_L");
                        break;
                    case "Arrow_R3": //è„ñ ç∂é¸ÇË
                        cubemover.move("U_L");
                        Debug.Log("R3");
                        break;
                    case "Arrow_R4":
                        cubemover.move("Fm_R");
                        break;
                    case "Arrow_R50":
                        cubemover.move("A_FR");
                        break;
                    case "Arrow_R51":
                        cubemover.move("A_FL");
                        break;
                    case "Arrow_R6":
                        cubemover.move("Fm_L");
                        break;
                    case "Arrow_R7":
                        cubemover.move("D_R");
                        break;
                    case "Arrow_R8":
                        cubemover.move("Um_R");
                        break;
                    case "Arrow_R9": //è„ñ âEâÒÇË
                        cubemover.move("U_R");
                        Debug.Log("R9");
                        break;
                    case "Arrow_U1":
                        cubemover.move("B_R");
                        break;
                    case "Arrow_U2":
                        cubemover.move("Fm_R");
                        break;
                    case "Arrow_U3":
                        cubemover.move("F_R");
                        break;
                    case "Arrow_U4":
                        cubemover.move("Rm_B");
                        break;
                    case "Arrow_U50":
                        cubemover.move("A_RB");
                        break;
                    case "Arrow_U51":
                        cubemover.move("A_RF");
                        break;
                    case "Arrow_U6":
                        cubemover.move("Rm_F");
                        break;
                    case "Arrow_U7":
                        cubemover.move("B_L");
                        break;
                    case "Arrow_U8":
                        cubemover.move("Fm_L");
                        break;
                    case "Arrow_U9":
                        cubemover.move("F_L");
                        break;
                }
            }
        }
    }

}
