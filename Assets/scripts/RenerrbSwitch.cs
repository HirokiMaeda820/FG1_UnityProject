using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenerrbSwitch : MonoBehaviour
{
    private GameObject _goal;
    private Goal _goalScript;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _goal = GameObject.Find("GoalCollider");
        _goalScript = _goal.GetComponent<Goal>();

        if (this.transform.tag == "CenterCube")
        {
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_goalScript.GetIsGoal())
        {
            rb.isKinematic = false;

            if (this.transform.tag == "CenterCube")
            {
                this.gameObject.SetActive(false);
            }
        }
        else if (!_goalScript.GetIsGoal())
        {
            rb.isKinematic = true;
        }
    }
}
