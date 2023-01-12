using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CMFreeLookSpd : MonoBehaviour
{
    CinemachineFreeLook _camera;
    Slider _slider;

    static private float spd;

    // Start is called before the first frame update

    private void Awake()
    {
        _slider = GameObject.Find("pSlider").GetComponent<Slider>();
    }

    void Start()
    {
        _camera = GetComponent<CinemachineFreeLook>();
        //_slider = GameObject.Find("pSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _camera.m_XAxis.m_MaxSpeed = _slider.value;

    }
}
