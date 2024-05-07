using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]


public class microwavedoor : MonoBehaviour
{
    public GameObject door;
    public GameObject doorhighlight;
    public GameObject doorclosesfx;
    public GameObject background3;
    public GameObject background2;

    void OnMouseOver()
    {
        doorhighlight.SetActive(true);
        door.SetActive(false);
    }
    void OnMouseExit()
    {
        doorhighlight.SetActive(false);
        door.SetActive(true);
    }
    void OnMouseDown()
    {
        background3.SetActive(true);
        background2.SetActive(false);
        doorclosesfx.SetActive(true);

    }
   
      
    
}
