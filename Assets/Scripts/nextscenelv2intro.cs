using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscenelv2intro : MonoBehaviour
{
    void Start()
    {
        Invoke("leveltwo", 15);


    }

    // Update is called once per frame
    void leveltwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}