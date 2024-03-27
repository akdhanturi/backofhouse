using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dialog_Scroller : MonoBehaviour
{
	public float perCharacterInterval = 0.01f; //0.03 before
	//public float perWordInterval = 0.025f; //0.045 before
	//public float perPunctuationInterval = 0.03f; // 0.06 before
	public bool useOnce = true;
	public bool playSound = true;
	//public string soundToPlay = "dialog_baritone";
	
	//public IntroHandler m_IntroHandler { get; set; }
	public bool textEnd = false;
	
	public string ObjectToDeactivate = "";
	
	public string dialogText
	{
		get
		{
			return dialogtext;
		}

		set
		{
			dialogtext = value;
			textEnd = false;
			lastCharTime = 0;
			nextInterval = 0;
			charIdx = 0;
		}
	}
	
	TextMeshProUGUI dialog;
	string dialogtext;
	string display;
	float lastCharTime;
	float nextInterval;
	int charIdx;
	private bool highlight = false;
	private int highlightCount = 0;
	
	public bool finished
	{
		get
		{
			return charIdx >= dialogtext.Length - 1; //Todo: null ref on span
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
	    dialog = GetComponent<TextMeshProUGUI>();
	    lastCharTime = 0;
	    nextInterval = perCharacterInterval;
	    charIdx = 0;
		display = "";
		dialogtext = dialog.text;
	    
	    //Debug.Log("Text: " + dialog.text);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogText != "" && dialogtext != null)
        {
	        if (charIdx < dialogtext.Length)
	        {
		        if (Time.time >= lastCharTime + nextInterval)
		        {
        					char currentChar = dialogtext[charIdx];
                            
	                        currentChar = dialogtext[charIdx];

	                        //if (playSound) AudioManager.PlaySound2D(DialogManager.currentDialogSoundKey);
                            //if (playSound) AudioManager.PlaySound2D(soundToPlay); //----------------------------------------------------------------------------PLAY SOUND!
        					display += currentChar;
        					dialog.text = display;
        					charIdx++;
        					lastCharTime = Time.time;
		        }
	        }
        			else
        			{
        				//if (m_IntroHandler != null) m_IntroHandler.dialogEnd = true;
                        //if (useOnce) Destroy(this);
        			}
	    }
        //Debug.Log("Text: " + dialog.text);
        GetComponent<TextMeshProUGUI>().text = display;
    }
    
    public void Clear()
    {
	    dialog.text = "";
	    display = "";
    }

    public void FinishDialog()
    {
	    if(dialogtext == null || dialog == null) return;
	    
	    charIdx = dialogText.Length - 1;
	    dialog.text = dialogtext;
    }
    
    //reset the dialog on enable
    void OnEnable()
    {
	    lastCharTime = 0;
	    nextInterval = perCharacterInterval;
	    charIdx = 0;
	    display = "";
    }
    
}

