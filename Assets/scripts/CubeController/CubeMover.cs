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

    private bool isLocked; //true:ロック false:オフ
    public AudioClip audioFinished;
    public AudioClip[] audioRot;

    AudioSource audioSource;
    Vector3 rotation;
    float rotation_sum;
    //List<float> speeds;
    private float rotateSpeed = 1.6f; //スピード
    Transform root;
    bool shouldDestroy;

    // Start is called before the first frame update
    void Start()
    {
        root = null;
        isLocked = false;

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

    void moveCubes(Vector3 axis, bool is90Degree, bool isAll, int _orientation)
    {
        if (isAvailable())
        {
            audioSource.clip = audioRot[Random.Range(0, audioRot.Length)];
            audioSource.volume = 0.25f;
            audioSource.Play();

            List<Transform> ts = findCubesInFront(axis, is90Degree, isAll);
            GameObject emptyGO = new GameObject();
            root = emptyGO.transform;
            foreach (Transform t in ts)
            {
                t.SetParent(root);

            }
            if (axis == rootCube.up && is90Degree == false && isAll == false && (_orientation == 1 || _orientation == -1))
            {
                player.SetParent(root);
                Debug.Log("こんにちは");
            }
            rotation = axis * _orientation * rotateSpeed;
        }
    }


    void cleanRoot()
    {
        if (root != null)
        {
            shouldDestroy = true;
        }
    }

    List<Transform> findCubesInFront(Vector3 axis, bool is90Degree, bool isAll)
    {
        List<Transform> result = new List<Transform>();
        if (isAll)
        {
            for (int i = 0; i < rootCube.childCount; i++)
            {
                Transform t = rootCube.GetChild(i);
                Vector3 v = t.position - centerCube.position;
                if (v.magnitude > 1e-4)
                {
                    result.Add(t);
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
                    if ((!is90Degree) && (cosine > 1e-4))
                    {
                        result.Add(t);
                    }
                    else if (is90Degree && (cosine < 1e-4))
                    {
                        result.Add(t);
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
        isLocked = true; //ロック
        switch (code)
        {
            case "A_FL":
                moveCubes(rootCube.forward, false, true, 1);
                break;
            case "A_FR":
                moveCubes(rootCube.forward, false, true, -1);
                break;
            case "A_RF":
                moveCubes(rootCube.right, false, true, -1);
                break;
            case "A_RB":
                moveCubes(rootCube.right, false, true, 1);
                break;
            case "A_UR":
                moveCubes(rootCube.up, false, true, -1);
                break;
            case "A_UL":
                moveCubes(rootCube.up, false, true, 1);
                break;
            case "F_L":
                moveCubes(-rootCube.forward, false, false, -1);
                break;
            case "F_R":
                moveCubes(-rootCube.forward, false, false, 1);
                break;
            case "Fm_L":
                moveCubes(-rootCube.forward, true, false, -1);
                break;
            case "Fm_R":
                moveCubes(-rootCube.forward, true, false, 1);
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
            case "Rm_F":
                moveCubes(rootCube.right, true, false, -1);
                break;
            case "Rm_B":
                moveCubes(rootCube.right, true, false, 1);
                break;
            case "L_F":
                moveCubes(-rootCube.right, false, false, 1);
                break;
            case "L_B":
                moveCubes(-rootCube.right, false, false, -1);
                break;
            case "U_R"://
                moveCubes(rootCube.up, false, false, -1);
                break;
            case "U_L"://
                moveCubes(rootCube.up, false, false, 1);
                break;
            case "Um_R":
                moveCubes(rootCube.up, true, false, -1);
                break;
            case "Um_L":
                moveCubes(rootCube.up, true, false, 1);
                break;
            case "D_R":
                moveCubes(-rootCube.up, false, false, 1);
                break;
            case "D_L":
                moveCubes(-rootCube.up, false, false, -1);
                break;
        }
        isLocked = false; //ロック解除する
        gameManager.subRotateCount();
    }
    public bool IsLocked()
    {
        return isLocked;
    }
}

