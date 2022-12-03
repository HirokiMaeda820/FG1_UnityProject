using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    private bool isGoal = false;

    public GameObject NextBotton;
    public GameObject ClearText;


    private bomb _bomb;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        NextBotton.SetActive(false);
        ClearText.SetActive(false);
        isGoal = false;
        _bomb = GetComponent<bomb>();
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

            NextBotton.SetActive(true);
            ClearText.SetActive(true);
            isGoal = true;
            Debug.Log("ÉSÅ[Éã");
        }
    }

    public bool GetIsGoal() { return isGoal; }
}
