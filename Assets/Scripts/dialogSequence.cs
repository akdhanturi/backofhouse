using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogSequence : MonoBehaviour
{
    public List<GameObject> allTextBubbles;
    int currentVisible = 0;
    //public List<String> allDialogs;
    //public List<dialog_Scroller> allScrollers;
    // Start is called before the first frame update
    void Start()
    {
        //turn off all text bubbles
        foreach (GameObject textBubble in allTextBubbles)
        {
            textBubble.SetActive(false);
        }
        //turn on first text bubble
        allTextBubbles[0].SetActive(true);
        currentVisible = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if( allTextBubbles[currentVisible].GetComponentInChildren<dialog_Scroller>().finished)
        {
            //turn off current text bubble
            //allTextBubbles[currentVisible].SetActive(false);
            if (currentVisible > 0)
            {
                if (allTextBubbles[currentVisible - 1].gameObject.activeSelf)
                {
                    allTextBubbles[currentVisible - 1].SetActive(false);
                }
                
            }
            //turn on next text bubble
            if (currentVisible < allTextBubbles.Count - 1)
            {
                currentVisible++; 
            }
            
            if (currentVisible < allTextBubbles.Count)
            {
                allTextBubbles[currentVisible].SetActive(true);
            }
        }
    }
}
