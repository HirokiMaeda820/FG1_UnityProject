using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenImage : MonoBehaviour
{
    public GameObject kaitenImage;

    // Start is called before the first frame update
    void Start()
    {
        kaitenImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log(collision.gameObject.name); // ‚Ô‚Â‚©‚Á‚½‘ŠŽè‚Ì–¼‘O‚ðŽæ“¾
        if (other.gameObject.tag == "Player")
        {
            kaitenImage.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        kaitenImage.SetActive(false);
    }
}
