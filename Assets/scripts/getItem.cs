using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class getItem : MonoBehaviour
{
    /// <summary>Player ‚ªN“ü‚µ‚½‚ÉÀs‚·‚é‚±‚Æ</summary>
    [SerializeField] UnityEvent _onEnter = default;
    /// <summary>ˆê“x“®ì‚µ‚½‚©‚Ç‚¤‚©</summary>
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
