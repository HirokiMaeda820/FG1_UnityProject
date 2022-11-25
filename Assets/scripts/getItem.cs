using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class getItem : MonoBehaviour
{
    /// <summary>Player ���N���������Ɏ��s���邱��</summary>
    [SerializeField] UnityEvent _onEnter = default;
    /// <summary>��x���삵�����ǂ���</summary>
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
