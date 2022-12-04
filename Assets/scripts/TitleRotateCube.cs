using UnityEngine;

public class TitleRotateCube : MonoBehaviour
{
    public float rotateX = 0;

    public float rotateY = 0;

    public float rotateZ = 0;

    // Update is called once per frame
    void Update()
    {
        // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
        // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}