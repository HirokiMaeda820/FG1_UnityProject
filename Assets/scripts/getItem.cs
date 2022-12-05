using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class getItem : MonoBehaviour
{
    /// <summary>Player が侵入した時に実行すること</summary>
    [SerializeField] UnityEvent _onEnter = default;
    /// <summary>一度動作したかどうか</summary>
    bool _isFinished = false;


    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)    
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            
            if (!_isFinished)
            {
                _onEnter.Invoke();
                _isFinished = true;
            }
        }
    }
}
