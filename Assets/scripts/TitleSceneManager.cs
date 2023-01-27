using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
    public GameManager gameManager;
    public string nextScene;
   
    AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameManager.ChangeScene(nextScene);
            audioSource.PlayOneShot(audioClip);  
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    gameManager.ChangeScene(nextScene);
        //}
    }
}
