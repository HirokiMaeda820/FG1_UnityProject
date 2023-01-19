using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CMFreeLookSpd : MonoBehaviour
{
    CinemachineFreeLook _camera;
    Slider _slider;

    static private float spd = 300;

    // Start is called before the first frame update

    private void Awake()
    {
        _slider = GameObject.Find("pSlider").GetComponent<Slider>();
    }

    void Start()
    {
        _camera = GetComponent<CinemachineFreeLook>();
        //_slider = GameObject.Find("pSlider").GetComponent<Slider>();

        _slider.value = spd;
    }

    // Update is called once per frame
    void Update()
    {
        spd = _slider.value;

        _camera.m_XAxis.m_MaxSpeed = spd;

    }
}
