using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyStartImage : MonoBehaviour
{
    float timer = 0;
    Color color;

    bool startFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        color = this.gameObject.GetComponent<Image>().color;
        startFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startFlag)
        {

            if (timer <= 1.8f) timer += Time.deltaTime;

            if (timer > 1.8f)
            {

                color.a -= 0.05f;
                this.gameObject.GetComponent<Image>().color = color;

                //è¡Ç¶ÇΩÇÁÅ@
                if (color.a <= 0)
                {
                    this.gameObject.SetActive(false);
                    color.a = 1;
                    this.gameObject.GetComponent<Image>().color = color;
                    startFlag = true;
                }
            }
        }
    }

    public bool GetStartFlag()
    {
        return startFlag;
    }
}
