using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModeImageChanger : MonoBehaviour
{

    public CameraSwitcher cameraSwitcher;

    public GameObject button1;
    public GameObject button2;

    public Sprite on1;
    public Sprite on2;
    public Sprite off1;
    public Sprite off2;

    public Slider slider;
    public GameObject fill;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        //fill = slider.transform.Find("Fill").gameObject;
        //background = slider.transform.Find("Background").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //FreeLook
        if (!cameraSwitcher.GetPlayerMode())
        {
            button1.GetComponent<Image>().sprite = on1;
            button2.GetComponent<Image>().sprite = off2;

            slider.interactable = true;
            fill.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            background.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        //Follow
        else if (cameraSwitcher.GetPlayerMode())
        {
            button1.GetComponent<Image>().sprite = off1;
            button2.GetComponent<Image>().sprite = on2;

            slider.interactable = false;
            fill.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            background.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);

        }
    }
}
