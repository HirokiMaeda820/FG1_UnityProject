using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    //[SerializeField] GameObject text;
    private bool isAudioEnd;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isAudioEnd = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioClip);
            isAudioEnd = true;
        }
        if (!audioSource.isPlaying && isAudioEnd)
        {
           // text.SetActive(true);
        }
        else
        {
           // text.SetActive(false);
        }
    }

    public void OnClick()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
