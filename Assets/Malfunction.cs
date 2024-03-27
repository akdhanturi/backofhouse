using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Malfunction : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Active");
        }
    }
}
