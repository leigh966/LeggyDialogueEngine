using LeggyDialogLib;
using LeggyTreeLib;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeEditor : MonoBehaviour
{
    DialogueTree tree;
    public NodeBehaviour rootNodeObject;
    public GameObject nodeObjectPrefab, canvas, linePrefab, savePopup, openPopup;
    public float zoomSpeed;
    public Vector3 childDisplacement;
    public float camMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        tree = new DialogueTree("", "");
        rootNodeObject.node = tree.ConversationStart;
 
    }

    private void handleWASD()
    {
        if (Input.GetKey("d"))
        {
            canvas.transform.Translate(-camMoveSpeed, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            canvas.transform.Translate(camMoveSpeed, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            canvas.transform.Translate(0,-camMoveSpeed, 0);
        }
        if (Input.GetKey("s"))
        {
            canvas.transform.Translate(0, camMoveSpeed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        canvas.transform.localScale = new Vector3(canvas.transform.localScale.x+scroll * zoomSpeed,
            canvas.transform.localScale.y + scroll * zoomSpeed,
            canvas.transform.localScale.z + scroll * zoomSpeed);
        handleWASD();
    }

    private void AddLine(Transform parentNodeTransform, Transform childNodeTransform)
    {
        var line = Instantiate(linePrefab, canvas.transform).GetComponent<LineBehaviour>();
        line.parent = parentNodeTransform;
        line.child = childNodeTransform;
        line.canvas = canvas.transform;
    }

    public NodeBehaviour AddNode(NodeBehaviour parentNode)
    {
        parentNode.node.AddChild(new DialogueOption("", ""));
        var newNodeBehaviour = Instantiate(nodeObjectPrefab, canvas.transform).GetComponent<NodeBehaviour>();
        newNodeBehaviour.transform.position = parentNode.transform.position + childDisplacement * canvas.transform.localScale.x;
        newNodeBehaviour.transform.localScale = Vector3.one * 0.4f;
        newNodeBehaviour.node = parentNode.node.Children[parentNode.node.Children.Length-1];
        newNodeBehaviour.editor = this;
        AddLine(parentNode.transform, newNodeBehaviour.transform);
        return newNodeBehaviour;
    }


    private void BuildTree(ITreeNode<DialogueOption> parentNode, NodeBehaviour parentNodeObject)
    {

        foreach(var child in parentNode.Children)
        {
            var childObject = AddNode(parentNodeObject);
            childObject.dialogueField.text = child.Value.PlayerDialog;
            childObject.responseField.text = child.Value.Response;
            BuildTree(child, childObject);
        }
    }

    public void LoadTree(string path)
    {
       tree = DialogueTree.Open(path);
        //destroy all nodes
        rootNodeObject.dialogueField.text = tree.ConversationStart.Value.PlayerDialog;
        rootNodeObject.responseField.text = tree.ConversationStart.Value.Response;
        BuildTree(tree.ConversationStart, rootNodeObject);
    }

    public void OpenSavePopup()
    {
        savePopup.SetActive(true);
    }

    public void OpenOpenPopup()
    {
        openPopup.SetActive(true);
    }


    public void Save(string name)
    {
        tree.Save(name+".dtree");
    }

}
