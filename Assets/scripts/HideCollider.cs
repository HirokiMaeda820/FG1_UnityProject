using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCollider : MonoBehaviour
{
    public CameraSwitcher cameraSwitcher;
    Collider _Collider;
    // Start is called before the first frame update
    void Start()
    {
        _Collider = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraSwitcher.CameraSwitch() == (int)CameraSwitcher.SwitchName.SELECT)
            _Collider.enabled = false;
        else
            _Collider.enabled = true;
    }
}
