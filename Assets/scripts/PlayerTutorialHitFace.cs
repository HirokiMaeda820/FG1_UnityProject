using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorialHitFace : MonoBehaviour
{
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Face6")
        {
            hit = true;
        }
        else
        {
            hit = false;

        }
    }

    public bool GetHitFace() { return hit; }
}
