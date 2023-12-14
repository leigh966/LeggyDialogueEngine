using LeggyDialogLib;
using LeggyTreeLib;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour
{

    public ITreeNode<DialogueOption> node;
    public NodeEditor editor;
    public TMP_InputField dialogueField, responseField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChild()
    {
        editor.AddNode(this);
    }
    Vector3 diff = Vector3.zero;
    public void OnMouseDrag()
    {
        transform.position = Input.mousePosition - diff;
    }

    public void OnBeginDrag()
    {
        diff = Input.mousePosition - transform.position;
    }

    public void UpdateNode()
    {
        node.Value.PlayerDialog = dialogueField.text;
        node.Value.Response = responseField.text;
    }
}
