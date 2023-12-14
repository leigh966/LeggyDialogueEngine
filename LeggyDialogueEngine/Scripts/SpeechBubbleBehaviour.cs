using LeggyDialogLib;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechBubbleBehaviour : MonoBehaviour
{
    public TMP_Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetText(string text)
    {
        dialogueText.text = text;
    }
}
