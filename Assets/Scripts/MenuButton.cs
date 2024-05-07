using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour
{
    //public float time;

    public GameObject menuenable;
    public GameObject menudisable;

    public void playGame()
    {
        //menuenable.SetActive(true);
        //menudisable.SetActive(false);
        Invoke("Loadintro", 1);
    }

    void Loadintro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
