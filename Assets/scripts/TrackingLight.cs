using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingLight : MonoBehaviour
{   
    public GameObject mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = mainCamera.transform.position;
        this.transform.rotation = mainCamera.transform.rotation;
    }
}
