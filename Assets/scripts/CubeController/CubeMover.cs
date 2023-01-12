using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMover : MonoBehaviour
{
    public Transform centerCube;
    public Transform rootCube;

    public Transform player;

    public GameManager gameManager;

    private bool isLocked; //true:���b�N false:�I�t
    public bool isRotate;

    public AudioClip audioFinished;
    public AudioClip[] audioRot;

    AudioSource audioSource;
    Vector3 rotation;
    float rotation_sum;
    //List<float> speeds;
    private float rotateSpeed = 1.6f; //�X�s�[�h
    Transform root;
    bool shouldDestroy;

    // Start is called before the first frame update
    void Start()
    {
        root = null;
        isLocked = false;
        isRotate = false;
        rotation_sum = 0;
        audioSource = transform.GetComponent<AudioSource>();
        audioSource.loop = false; // for audio looping
    }

    // Update is called once per frame
    void Update()
    {
        if (root != null)
        {
            if (shouldDestroy)
            {
                if (root.childCount > 0)
                {
                    for (int i = 0; i < root.childCount; i++)
                    {
                        root.GetChild(i).SetParent(rootCube);
                    }
                }
                else
                {
                    Destroy(root.gameObject);
                    root = null;
                    player.transform.parent = null; 
                    shouldDestroy = false;
                }
            }
            else
            {
                root.Rotate(rotation);
                rotation_sum += rotation.magnitude;
                if (rotation_sum >= 90)
                {
                    rotation_sum = 0;
                    if (rotation.x != 0)
                    {
                        if (rotation.x < 0)
                        {
                            root.eulerAngles = new Vector3(-90, root.eulerAngles.y, root.eulerAngles.z);
                        }
                        else
                        {
                            root.eulerAngles = new Vector3(90, root.eulerAngles.y, root.eulerAngles.z);
                        }
                    }
                    else if (rotation.y != 0)
                    {
                        if (rotation.y < 0)
                        {
                            root.eulerAngles = new Vector3(root.eulerAngles.x, -90, root.eulerAngles.z);
                        }
                        else
                        {
                            root.eulerAngles = new Vector3(root.eulerAngles.x, 90, root.eulerAngles.z);
                        }
                    }
                    else
                    {
                        if (rotation.z < 0)
                        {
                            root.eulerAngles = new Vector3(root.eulerAngles.x, root.eulerAngles.y, -90);
                        }
                        else
                        {
                            root.eulerAngles = new Vector3(root.eulerAngles.x, root.eulerAngles.y, 90);
                        }
                    }
                    cleanRoot();

                }
            }
        }
    }

    void moveCubes(Vector3 axis, bool is90Degree, bool isMid, int _orientation)
    {
        if (isAvailable())
        {
            audioSource.clip = audioRot[Random.Range(0, audioRot.Length)];
            audioSource.volume = 0.25f;
            audioSource.Play();

            List<Transform> ts = findCubesInFront(axis, is90Degree, isMid);
            GameObject emptyGO = new GameObject();
            root = emptyGO.transform;
            foreach (Transform t in ts)
            {
                t.SetParent(root);

            }
            if (axis == rootCube.up && is90Degree == false && (_orientation == 1 || _orientation == -1))
            {
                player.SetParent(root);
            }
            rotation = axis * _orientation * rotateSpeed;
           // Debug.Log(rotation);
            isRotate = true;
        }
        else
        {
            isRotate= false;
        }
    }


    void cleanRoot()
    {
        if (root != null)
        {
            shouldDestroy = true;
        }
    }

    List<Transform> findCubesInFront(Vector3 axis, bool is90Degree, bool isMid)
    {
        List<Transform> result = new List<Transform>();

        // �����E�̒��Ԃ̗�
        Debug.Log(isMid);
        if (isMid)
        {
            
            for (int i = 0; i < rootCube.childCount; i++)
            {
                Transform t = rootCube.GetChild(i);
                Vector3 v = t.position - centerCube.position;
                if (v.magnitude > 1e-4)
                {

                    float cosine = Vector3.Dot(v, axis) / (v.magnitude * axis.magnitude);
                    if (is90Degree) cosine = Mathf.Abs(cosine);

                    // 0.0005 �͒��i����̃x�N�g���̒l
                    // 0.5    �͊O��̃x�N�g���̒l�̔�r�̊�l
                    if ((!is90Degree))
                    {
                        Debug.Log("�����܂ł͒ʂ�");
                        if (cosine < 0.5f && cosine > 0.0005f)
                            result.Add(t); Debug.Log(cosine);
                    }
                    else if (is90Degree)
                    {
                        Debug.Log("�����܂ł͒ʂ�");
                        if (cosine < 0.5f && cosine > 0.0005f)
                            result.Add(t); Debug.Log(cosine);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < rootCube.childCount; i++)
            {
                Transform t = rootCube.GetChild(i);
                Vector3 v = t.position - centerCube.position;
                if (v.magnitude > 1e-4)
                {
                    float cosine = Vector3.Dot(v, axis) / (v.magnitude * axis.magnitude);
                    if (is90Degree) cosine = Mathf.Abs(cosine);
                    if ((!is90Degree) && (cosine > 0.5))
                    {
                        result.Add(t); Debug.Log(cosine);
                    }                    
                    else if (is90Degree && (cosine < 0.0005))
                    {
                        result.Add(t); Debug.Log(cosine);
                    }
                   
                    
                }
            }          
        }
        return result;
    }

    public bool isAvailable()
    {
        if (root == null && shouldDestroy == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void move(string code)
    {
        isLocked = true; //���b�N
        switch (code)
        {
            // F��front  ��ʉ��ɉ�]
            // B��back   ��ʑO�ɉ�]
            // R��right  �E�����]
            // L��left   �������]
            // U��up     �ŏ�����]
            // D��down   �ŉ������]
            // c��center ���i����̉�]
            // m��mid�@�@2,4�̒��i��̉�]
            // 


            case "F_L":
                moveCubes(-rootCube.forward, false, false, -1);
                break;
            case "F_R":
                moveCubes(-rootCube.forward, false, false, 1);
                break;       
            case "Fc_L":
                moveCubes(-rootCube.forward, true, false, -1);
                break;
            case "Fc_R":
                moveCubes(-rootCube.forward, true, false, 1);
                break;

            case "Fm_R":
                moveCubes(-rootCube.forward, false, true, 1);
                break;
            case "Fm_L":
                moveCubes(-rootCube.forward, false, true, -1);
                break;

            case "Bm_R":
                moveCubes(rootCube.forward, false, true, -1);
                break;
            case "Bm_L":
                moveCubes(rootCube.forward, false, true, 1);
                break;

            case "B_L":
                moveCubes(rootCube.forward, false, false, 1);
                break;
            case "B_R":
                moveCubes(rootCube.forward, false, false, -1);
                break;


            case "R_F":
                moveCubes(rootCube.right, false, false, -1);
                break;
            case "R_B":
                moveCubes(rootCube.right, false, false, 1);
                break;
            case "Rc_F":
                moveCubes(rootCube.right, true, false, -1);
                break;
            case "Rc_B":
                moveCubes(rootCube.right, true, false, 1);
                break;
            case "L_F":
                moveCubes(-rootCube.right, false, false, 1);
                break;
            case "L_B":
                moveCubes(-rootCube.right, false, false, -1);
                break;

            case "Lm_B":
                moveCubes(-rootCube.right, false, true, -1);
                break;
            case "Rm_B":
                moveCubes(rootCube.right, false, true, 1);
                break;

            case "Lm_F":
                moveCubes(rootCube.right, false, true, -1);
                break;
            case "Rm_F":
                moveCubes(-rootCube.right, false, true, 1);
                break;

            /// ��������]
            case "U_R"://
                moveCubes(rootCube.up, false, false, -1);
                break;
            case "U_L"://
                moveCubes(rootCube.up, false, false, 1);
                break;
            
            case "Uc_R":
                moveCubes(rootCube.up, true, false, -1);
                break;
            case "Uc_L":
                moveCubes(rootCube.up, true, false, 1);
                break;

            case "Um_R":
                moveCubes(rootCube.up, false, true, -1);
                break;
            case "Um_L":
                moveCubes(rootCube.up, false, true, 1);
                break;

            case "Dm_R":
                moveCubes(-rootCube.up, false, true, 1);
                break;
            case "Dm_L":
                moveCubes(-rootCube.up, false, true, -1);
                break;

            case "D_R":
                moveCubes(-rootCube.up, false, false, 1);
                break;
            case "D_L":
                moveCubes(-rootCube.up, false, false, -1);
                break;
        }
        isLocked = false; //���b�N��������
        gameManager.subRotateCount();
    }
    public bool IsLocked()//true:���b�N false:�I�t
    {
        return isLocked;
    }
    
    public bool GetIsRotate()
    {
        return isRotate;
    }
}

