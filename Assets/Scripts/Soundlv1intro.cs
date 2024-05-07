using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soundlv1intro : MonoBehaviour
{
    public GameObject BG;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Setactive", 6);
        Invoke("levelone", 46);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Setactive()
    {
        BG.SetActive(true);
    }
    void levelone()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
