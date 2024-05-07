using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechangeintro1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GameStart", 29);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
