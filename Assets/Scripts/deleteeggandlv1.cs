using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteeggandlv1 : MonoBehaviour
{
    public GameObject delete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            delete.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            delete.SetActive(false);

        }
    }
}
