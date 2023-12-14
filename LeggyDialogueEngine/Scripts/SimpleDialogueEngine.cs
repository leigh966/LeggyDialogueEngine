using LeggyDialogLib;
using LeggyTreeLib;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleDialogueEngine : MonoBehaviour
{
    public string dialogueTreePath;
    private DialogueTree tree;
    public SpeechBubbleBehaviour mySpeech, npcSpeech;
    public DialogueSelectorBehaviour selector;
    private ITreeNode<DialogueOption> currentNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSpeechBubbles(DialogueOption thisDialogue)
    {
        mySpeech.SetText(thisDialogue.PlayerDialog);
        npcSpeech.SetText(thisDialogue.Response);
    }

    void UpdateOptions()
    {
        List<DialogueOption> options = new List<DialogueOption>();
        foreach (var child in currentNode.Children)
        {
            options.Add(child.Value);
        }

        if(currentNode.Parent!=null) options.Add(new DialogueOption("Back", ""));
        
        selector.SetOptions(options);
    }

    public void Begin()
    {
        tree = DialogueTree.Open(dialogueTreePath);
        currentNode = tree.ConversationStart;
        DialogueOption thisDialogue = currentNode.Value;
        UpdateSpeechBubbles(thisDialogue);
        UpdateOptions();
    }

    public void GoBack()
    {
        currentNode = currentNode.Parent;
        UpdateSpeechBubbles(new DialogueOption("", ""));
    }

    public void Say(int i)
    {
        if (i >= currentNode.Children.Length)
        {
            GoBack();
        }
        else
        {
            var newNode = currentNode.Children[i];
            if (newNode.Children.Length > 0)
            {
                currentNode = newNode;
            }
            UpdateSpeechBubbles(newNode.Value);
        }
        
        UpdateOptions();
    }

}
