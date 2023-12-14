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
    public List<NodeBehaviour> children;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<NodeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NodeBehaviour AddChild()
    {
        var newNode = editor.AddNode(this);
        children.Add(newNode);
        return newNode;
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

    public void DestroyChildren()
    {
        foreach (var child in children)
        {
            child.Destroy();
        }
    }

    public void Destroy() 
    {
        DestroyChildren();
        Destroy(gameObject);
    }
}
