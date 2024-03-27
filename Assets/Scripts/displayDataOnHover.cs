using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayDataOnHover : MonoBehaviour
{
    public GameObject popUpWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        popUpWindow.SetActive(true);

    }

    void OnMouseExit() {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        popUpWindow.SetActive(false);
    }

}
