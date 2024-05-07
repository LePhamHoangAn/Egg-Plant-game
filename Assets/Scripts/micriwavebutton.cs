using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class micriwavebutton : MonoBehaviour
{
    public GameObject buttonhighlight;
    public GameObject buzzing;
    public GameObject background4;

    // Start is called before the first frame update
    void OnMouseOver()
    {
        buttonhighlight.SetActive(true);
    }
    void OnMouseExit()
    {
        buttonhighlight.SetActive(false);
    }
    void OnMouseDown()
    {
        buzzing.SetActive(true);
        background4.SetActive(true);

        Invoke("Loadcine", 5);
    }

    void Loadcine()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
