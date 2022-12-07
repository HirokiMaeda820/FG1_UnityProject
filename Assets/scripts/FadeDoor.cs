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
            StartFadeOut(); //boolにチェックが入っていたら実行

        }
        
    }

    void StartFadeOut()
    {
        alfa -= fadeSpeed;         // 不透明度を下げる
        SetAlpha();               // 変更した透明度を反映する
        if (alfa <= 0)              // 完全に透明になったら処理を抜ける
        {
            isFadeOut = false;     // boolのチェックが外れる
            fenceRenderer.enabled = false;  // Materialの描画をオフにする
            fenceCollider.enabled = false;
        }
        Debug.Log("消えた");
    }

    void SetAlpha()
    {
        fenceRenderer.material.color = new Color(red, green, bule, alfa);
        // 変更した不透明度を含むMaterialのカラーを反映する
    }

}
