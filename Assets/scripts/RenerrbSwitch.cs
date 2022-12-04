using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenerrbSwitch : MonoBehaviour
{
    private Goal _goal;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        _goal = GameObject.Find("GoalCollider").GetComponent<Goal>();

        if (this.transform.tag == "CenterCube")
        {
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_goal == null) return;

        if (_goal.GetIsGoal())
        {
            rb.isKinematic = false;

            if (this.transform.tag == "CenterCube")
            {
                this.gameObject.SetActive(false);
            }
        }
        else if (!_goal.GetIsGoal())
        {
            rb.isKinematic = true;
        }
    }
}
