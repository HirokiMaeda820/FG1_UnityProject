using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCollider : MonoBehaviour
{
    public CameraSwitcher cameraSwitcher;
    Collider _Collider;
    Renderer _Renderer;

    Color defColor;

    public bool goal = false;
    public bool key = false;

    // Start is called before the first frame update
    void Start()
    {
        _Collider = this.GetComponent<Collider>();
        if (!goal)_Renderer = this.GetComponent<Renderer>();

        if (!goal) defColor = _Renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
        {
            _Collider.enabled = false;
            if (!goal&&!key) _Renderer.material.color =
                new Color(_Renderer.material.color.r, _Renderer.material.color.g, _Renderer.material.color.b, 0.5f); ;
        }
        else
        {
            _Collider.enabled = true;
            if (!goal) _Renderer.material.color = defColor;
        }
    }
}
