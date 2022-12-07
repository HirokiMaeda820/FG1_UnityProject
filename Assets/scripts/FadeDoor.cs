using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDoor : MonoBehaviour
{

    public GameObject key;

    Renderer fenceRenderer;
    Collider fenceCollider;

    float red, green, bule, alfa;
    float fadeSpeed = 0.01f;
    public bool isFadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        fenceRenderer = this.GetComponent<Renderer>();
        fenceCollider = this.GetComponent<Collider>();
        red = fenceRenderer.material.color.r;
        green = fenceRenderer.material.color.g;
        bule = fenceRenderer.material.color.b;
        alfa = fenceRenderer.material.color.a; 
    }


    // Update is called once per frame
    void Update()
    {
        if (key.activeSelf == false)
        {
            StartFadeOut(); //bool�Ƀ`�F�b�N�������Ă�������s

        }
        
    }

    void StartFadeOut()
    {
        alfa -= fadeSpeed;         // �s�����x��������
        SetAlpha();               // �ύX���������x�𔽉f����
        if (alfa <= 0)              // ���S�ɓ����ɂȂ����珈���𔲂���
        {
            isFadeOut = false;     // bool�̃`�F�b�N���O���
            fenceRenderer.enabled = false;  // Material�̕`����I�t�ɂ���
            fenceCollider.enabled = false;
        }
        Debug.Log("������");
    }

    void SetAlpha()
    {
        fenceRenderer.material.color = new Color(red, green, bule, alfa);
        // �ύX�����s�����x���܂�Material�̃J���[�𔽉f����
    }

}
