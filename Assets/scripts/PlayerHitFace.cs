using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitFace : MonoBehaviour
{

    public ControlMode controlMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay(Collider other)
    //{

    //    controlMode.SwitchArrow(other.gameObject.tag);//タグいれる

    //    //other.gameObject.name
    //}

    private void OnCollisionStay(Collision other)
    {

        controlMode.SwitchArrow(other.gameObject.tag);//タグいれる

        //other.gameObject.name;
    }
}
