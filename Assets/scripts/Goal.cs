using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    private bool isGoal = false;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);

        isGoal = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            isGoal = true;
            Debug.Log("ÉSÅ[Éã");
        }
    }

    public bool GetIsGoal() { return isGoal; }
}
