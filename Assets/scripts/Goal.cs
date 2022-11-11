using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    GameObject gameclearText;

    private bool isGoal = false;
    //public GameObject NextBotton;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
       // NextBotton.SetActive(true);
        isGoal = true;
        Debug.Log("ÉSÅ[Éã");
    }

    public bool GetIsGoal() { return isGoal; }
}
