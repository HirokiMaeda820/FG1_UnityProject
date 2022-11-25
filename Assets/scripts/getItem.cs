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
    public GameObject Door;
    private Collider DoorCol;

    private void Start()
    {
       DoorCol= Door.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)    
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            DoorCol.isTrigger = true;
            if (!_isFinished)
            {
                _onEnter.Invoke();
                _isFinished = true;
            }
        }
    }
}
