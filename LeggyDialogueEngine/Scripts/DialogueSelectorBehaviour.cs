using LeggyDialogLib;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSelectorBehaviour : MonoBehaviour
{
    List<DialogueOption> options = new List<DialogueOption>();
    public TMP_Text text;
    public SimpleDialogueEngine engine;
    int selectedIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HandleControls()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            selectedIndex--;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
        }
        if(selectedIndex < 0)
        {
            selectedIndex = options.Count - 1;
        }
        if(selectedIndex >= options.Count) 
        {
            selectedIndex = 0;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            engine.Say(selectedIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "";
        for(int i = 0; i < options.Count; i++) 
        {
            if (i == selectedIndex) text.text += "> ";
            text.text += options[i].PlayerDialog + "\n";
        }
        HandleControls();
    }

    public void SetOptions(List<DialogueOption> options)
    {
        this.options = options;
    }
}
